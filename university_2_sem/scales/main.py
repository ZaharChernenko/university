import pygame
import drawing
from random import randint
from weight import Scale

pygame.init()
run = True
check = pygame.image.load("img/check.png")
cross = pygame.image.load("img/cross.png")
#инициализируем экран, чаши
screen = pygame.display.set_mode((1280, 720))
pygame.display.set_caption("Sigma scales")
pygame.display.set_icon(pygame.image.load("img/icon.png"))
#размечаем поле ввода
inputBox_x = 550
inputBox_y = 100
inputText = ""
needInput = False
answerIsGiven = False
#создаем чаши и счетчик веса
left_Pan, right_Pan = pygame.Surface((500, 145)), pygame.Surface((500, 145))
left_Pan.fill("WHITE")
right_Pan.fill("WHITE")
left_Pan_weight, right_Pan_weight = 0, 0
#грузики
x_position, y_position = 65, 500
weights_Dict = []
weights_Rand_Dict = []
rand_Dict = [i for i in range(1, 8)]
lost = rand_Dict.pop(randint(0, 6))
print(lost)
for i in range(1, 8):
    weights_Dict.append(Scale(x_position + 70 * (i - 1), y_position, i))
for i in range(6):
    weights_Rand_Dict.append(Scale(x_position + 680 + 70 * i, y_position, rand_Dict[i]))
Dict = weights_Dict + weights_Rand_Dict
#кнопка сравнения
compare_x, compare_y = 590, 600

while run:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            run = not run
        elif event.type == pygame.MOUSEBUTTONDOWN and not answerIsGiven:
            if event.button == 1:
                for weight_ in Dict:
                    if weight_.x <= event.pos[0] <= weight_.x + 50 and weight_.y <= event.pos[1] <= weight_.y + 50:
                        if weight_.y == 500:
                            if Dict.index(weight_) < 7:
                                weight_.y = 400
                            else:
                                weight_.y = 335
                                weight_.x = weight_.x - 680
                            left_Pan_weight += weight_.weight
                        else:
                            weight_.y = weight_.y_stock
                            weight_.x = weight_.x_stock
                            if event.pos[0] <= 640:
                                left_Pan_weight -= weight_.weight
                            else:
                                right_Pan_weight -= weight_.weight
                        screen.fill("black")
                        break
                if compare_x <= event.pos[0] <= compare_x + 100 and compare_y <= event.pos[1] <= compare_y + 50 and drawing.numberOfCompares != 2:
                    print(left_Pan_weight == right_Pan_weight)
                    drawing.Compare(screen, left_Pan_weight, right_Pan_weight)
                elif inputBox_x - 200 <= event.pos[0] <= inputBox_x + 50 and inputBox_y <= event.pos[1] <= inputBox_y + 50:
                    needInput = True
            elif event.button == 3:
                for weight_ in Dict:
                    if weight_.x <= event.pos[0] <= weight_.x + 50 and weight_.y <= event.pos[1] <= weight_.y + 50 and weight_.y == 500:
                        if Dict.index(weight_) < 7:
                            weight_.y = 400
                            weight_.x = weight_.x + 680
                        else:
                            weight_.y = 335
                        right_Pan_weight += weight_.weight
                        screen.fill("black")
                        break
        if event.type == pygame.KEYDOWN and needInput and not answerIsGiven:
            if event.key == pygame.K_RETURN:
                needInput = False
                answerIsGiven = True
            elif event.key == pygame.K_BACKSPACE:
                inputText = ""
                pygame.draw.rect(screen, (0, 0, 0), (inputBox_x, 50, 200, 200))
            else:
                if len(inputText) < 1 and event.unicode.isdigit():
                    inputText += event.unicode
    screen.blit(left_Pan, (50, 320))
    screen.blit(right_Pan, (730, 320))
    for i in range(1, 8):
        pygame.draw.rect(screen, "red", (weights_Dict[i - 1].x, weights_Dict[i - 1].y, 50, 50), 2)
        drawing.DrawText(screen, i, weights_Dict[i - 1].x, weights_Dict[i - 1].y, 25, 25)
    for i in range(1, 7):
        pygame.draw.rect(screen, "red", (weights_Rand_Dict[i - 1].x, weights_Rand_Dict[i - 1].y, 50, 50), 2)
    pygame.draw.rect(screen, "red", (compare_x, compare_y, 100, 50), 2)
    drawing.DrawText(screen, "compare", compare_x, compare_y, 50, 25)
    if drawing.numberOfCompares != 0:
        drawing.DrawText(screen, "enter the answer:", inputBox_x, inputBox_y, 0, 0)
        drawing.DrawText(screen, inputText, inputBox_x, inputBox_y, 90, 0)
    if answerIsGiven:
        if int(inputText) == lost:
            screen.blit(check, (700, 68))
        else:
            screen.blit(cross, (700, 68))
    pygame.display.update()
    #pygame.display.flip()