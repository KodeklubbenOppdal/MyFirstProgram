print("Hei, hva herter du?")
name = input();

svarOK = True
while svarOK:
    bra = input("Hei " + name+". Har du det bra?")
    if bra=="ja":
        print("Det er bra, jeg ogs�")
        svarOK = False
    elif bra =="nei":
        print("Det var synd")
        svarOK =False
    else:
        print("Pr�ve en gang til (ja eller nei)")

