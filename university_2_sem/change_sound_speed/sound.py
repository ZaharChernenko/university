from pydub import AudioSegment


def speed_change(sound, speed=1.0):
    sound.frame_rate = sound.frame_rate * speed
    return sound


speed = float(input("Enter speed:"))
sound = AudioSegment.from_wav("song.wav")
new_sound = speed_change(sound, speed)
new_sound.export("file.wav", format="wav")
print("Done!")
