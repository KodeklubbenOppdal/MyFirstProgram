/*
 Name:		LysbryterArduino.ino
 Created:	10/20/2015 3:25:16 PM
 Author:	HansenS
*/
String input_String;
bool input_StringComplete;
int outputPin = 2;

// the setup function runs once when you press reset or power the board
void setup() {
	Serial.begin(9600);
	pinMode(outputPin, OUTPUT);
	digitalWrite(outputPin, HIGH);

}

void loop() {
	if (input_StringComplete)
	{
		input_String.trim();

		if (input_String == "on")
		{
			digitalWrite(outputPin, true);
		}
		else if (input_String == "off")
		{
			digitalWrite(outputPin, true);
		}
		input_String = "";
		input_StringComplete = false;
	}

	delay(10);
}


void serialEvent() {
	while (Serial.available()) {
		char inChar = (char)Serial.read();
		input_String += inChar;
		if (inChar == '\n') {
			input_StringComplete = true;
		}
	}
}
