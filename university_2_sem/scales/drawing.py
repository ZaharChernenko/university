import pygame

# загружаем знаки сравнения
greater = pygame.image.load("img/bigger.png")
less = pygame.image.load("img/less.png")
equal = pygame.image.load("img/EQUAL.png")
numberOfCompares = 0


def Compare(screen, x, y):
    if x == y:
        screen.blit(equal, (608, 360))
    elif x > y:
        screen.blit(greater, (608, 360))
    else:
        screen.blit(less, (608, 360))
    global numberOfCompares
    numberOfCompares += 1


def DrawText(screen, line, x, y, addX, addY):
    font = pygame.font.SysFont("Arial", 20)
    text = font.render(str(line), True, "red")
    text_rect = text.get_rect(center=(x + addX, y + addY))
    screen.blit(text, text_rect)
