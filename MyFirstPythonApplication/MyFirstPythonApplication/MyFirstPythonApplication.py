print("Hei, hva herter du?")
name = input();

svarOK = True
while svarOK:
    bra = input("Hei " + name+". Har du det bra?")
    if bra=="ja":
        print("Det er bra, jeg ogsaa")
        svarOK = False
    elif bra =="nei":
        print("Det var synd")
        svarOK =False
    else:
        print("Prov en gang til (ja eller nei)")

