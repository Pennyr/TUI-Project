#include <ESP8266WiFi.h>        // Include the Wi-Fi library
#include <WiFiUdp.h>


#define D1 5
#define D2 4
#define D3 0
#define D4 2
#define D5 14
#define D6 12
#define D7 13
#define D8 15
#define D9 16

#define blue 0x42
#define red 0x52
#define green 0x47
#define vibrate 0x56

const char* ssid     = "";         // The SSID (name) of the Wi-Fi network you want to connect to
const char* password = "";     // The password of the Wi-Fi network

// Variables will change:
int D2_buttonState = 0;         // current state of the button
int D2_lastButtonState = 0;     // previous state of the button

int D3_buttonState = 0;         // current state of the button
int D3_lastButtonState = 1;     // previous state of the button

int D4_buttonState = 0;         // current state of the button
int D4_lastButtonState = 1;     // previous state of the button

int D8_buttonState = 0;         // current state of the button
int D8_lastButtonState = 1;     // previous state of the button
  
WiFiUDP Udp;

unsigned int localUdpPort = 11000;

IPAddress remoteIP(192,168,1,75);
int remotePort = 11001; //dan il port fejn ha nibatu il paketti

char incomingPacket[255];
char replyPacket[] = "Hi there! Got the message ESP8266 :-)";
char packetBuffer[50];
  
void setup() {
  Serial.begin(115200);         // Start the Serial communication to send messages to the computer
  delay(10);
  Serial.println('\n');
 
  pinMode(D2, INPUT);
  pinMode(D3, INPUT);
  pinMode(D4, INPUT);
  pinMode(D8, INPUT);

  pinMode(D1, OUTPUT);
  pinMode(D5, OUTPUT);
  pinMode(D6, OUTPUT);
  pinMode(D7, OUTPUT);
  pinMode(D9, OUTPUT);

  WiFi.begin(ssid, password);             // Connect to the network
  Serial.print("Connecting to ");
  Serial.print(ssid); Serial.println(" ...");

  int i = 0;
  while (WiFi.status() != WL_CONNECTED) { // Wait for the Wi-Fi to connect
    delay(1000);
    Serial.print(++i); Serial.print(' ');

    Udp.begin(localUdpPort);

  }

  Serial.println('\n');
  Serial.println("Connection established!");  
  Serial.print("IP address:\t");
  Serial.println(WiFi.localIP());         // Send the IP address of the ESP8266 to the computer
}

void loop() { 
/*
  Serial.print("Pin1: ");  
  Serial.print(digitalRead(D8));
  Serial.print(" Pin2: "); 
  Serial.print(digitalRead(D2));
  Serial.print(" Pin3: "); 
  Serial.print(digitalRead(D3));
  Serial.print(" Pin4: "); 
  Serial.print(digitalRead(D4));
  Serial.print("\n"); 
*/

    // read the pushbutton input pin:
    D2_buttonState = digitalRead(D2);  
    D3_buttonState = digitalRead(D3);  
    D4_buttonState = digitalRead(D4);
    D8_buttonState = digitalRead(D8);  
  
    // compare the buttonState to its previous state
    if (D2_buttonState != D2_lastButtonState) {
      // if the state has changed, increment the counter
      if (D2_buttonState == HIGH) {
        // if the current state is HIGH then the button went from off to on:
         digitalWrite(D1, LOW); 

        strcpy(packetBuffer,"This is a message from D1");
         
        if(Udp.beginPacket(remoteIP,remotePort) == 1)
        {
          //Udp.print("Test from udp print. ");
          Udp.write(packetBuffer,strlen(packetBuffer));
          if(Udp.endPacket() == 1)
          {
            Serial.println("endPacket ok");
          }
          else
          {
            Serial.println("endPacket fail");
          }
        }
         else
         {
          Serial.println("beginPacket fail");
         }
   
      } else {
        // if the current state is LOW then the button went from on to off:
        digitalWrite(D1, HIGH); 
      }
      // save the current state as the last state, for next time through the loop
      D2_lastButtonState = D2_buttonState;
    }

    // compare the buttonState to its previous state
    if (D3_buttonState != D3_lastButtonState) {
      // if the state has changed, increment the counter
      if (D3_buttonState == HIGH) {
        // if the current state is HIGH then the button went from off to on:
         digitalWrite(D5, LOW); 

        strcpy(packetBuffer,"This is a message from D5");
         
        if(Udp.beginPacket(remoteIP,remotePort) == 1)
        {
          //Udp.print("Test from udp print. ");
          Udp.write(packetBuffer,strlen(packetBuffer));
          if(Udp.endPacket() == 1)
          {
            Serial.println("endPacket ok");
          }
          else
          {
            Serial.println("endPacket fail");
          }
        }
         else
         {
          Serial.println("beginPacket fail");
         }        
         
      } else {
        // if the current state is LOW then the button went from on to off:
        digitalWrite(D5, HIGH); 
      }
      // save the current state as the last state, for next time through the loop
      D3_lastButtonState = D3_buttonState;
    }    
 
    // compare the buttonState to its previous state
    if (D4_buttonState != D4_lastButtonState) {
      // if the state has changed, increment the counter
      if (D4_buttonState == HIGH) {
        // if the current state is HIGH then the button went from off to on:
         digitalWrite(D6, LOW); 

        strcpy(packetBuffer,"This is a message from D6");
         
        if(Udp.beginPacket(remoteIP,remotePort) == 1)
        {
          //Udp.print("Test from udp print. ");
          Udp.write(packetBuffer,strlen(packetBuffer));
          if(Udp.endPacket() == 1)
          {
            Serial.println("endPacket ok");
          }
          else
          {
            Serial.println("endPacket fail");
          }
        }
         else
         {
          Serial.println("beginPacket fail");
         }       
         
      } else {
        // if the current state is LOW then the button went from on to off:
        digitalWrite(D6, HIGH); 
      }
      // save the current state as the last state, for next time through the loop
      D4_lastButtonState = D4_buttonState;
    }

    // compare the buttonState to its previous state
    if (D8_buttonState != D8_lastButtonState) {
      // if the state has changed, increment the counter
      if (D8_buttonState == HIGH) {
        // if the current state is HIGH then the button went from off to on:
         digitalWrite(D7, HIGH); 

        strcpy(packetBuffer,"This is a message from D7");
         
        if(Udp.beginPacket(remoteIP,remotePort) == 1)
        {
          //Udp.print("Test from udp print. ");
          Udp.write(packetBuffer,strlen(packetBuffer));
          if(Udp.endPacket() == 1)
          {
            Serial.println("endPacket ok");
          }
          else
          {
            Serial.println("endPacket fail");
          }
        }
         else
         {
          Serial.println("beginPacket fail");
         }
         
      } else {
        // if the current state is LOW then the button went from on to off:
        digitalWrite(D7, LOW);
      }
      // save the current state as the last state, for next time through the loop
      D8_lastButtonState = D8_buttonState;
    }

  
  int packetSize = Udp.parsePacket();
  if (packetSize)
  {
    Serial.printf("Received %d bytes from %s, port %d\n", packetSize, Udp.remoteIP().toString().c_str(), Udp.remotePort());
    int len = Udp.read(incomingPacket, 255);
    if (len > 0)
    {
      incomingPacket[len] = 0;
    }
    Serial.printf("UDP packet contents: %s\n", incomingPacket);

    Serial.printf("Sending bytes to %s, port %d\n", Udp.remoteIP().toString().c_str(), Udp.remotePort());
    Udp.beginPacket(Udp.remoteIP(), Udp.remotePort());
    Udp.write(replyPacket);
    Udp.endPacket();
  }
}
