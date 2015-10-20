void setup()
{
	Serial.begin(9600);
	randomSeed(analogRead(0));
}

void loop()
{
	int randNr = random(254);
	Serial.println(randNr);
	delay(1000);
}
