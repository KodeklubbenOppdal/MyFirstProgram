
import serial

ser = serial.Serial("COM13", 9600)
while True:
    print ser.readline()