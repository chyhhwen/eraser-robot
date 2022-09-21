#include <SoftwareSerial.h>
SoftwareSerial BT(6,7); // 接收腳, 傳送腳
#define pwm 200
#define pwn 230
void setup() 
{
  Serial.begin(9600);
  BT.begin(9600);
  //馬達一
  pinMode(10,OUTPUT); // M1Pin1
  pinMode(9,OUTPUT);  // M1Pin2
  pinMode(11,OUTPUT); // E1Pin
  //馬達二
  pinMode(5,OUTPUT);  // M2Pin1
  pinMode(4,OUTPUT);  // M2Pin2
  pinMode(3,OUTPUT);  // E2Pin
  motorstop();
}
char c;
void loop() 
{
    c = BT.read();
  switch (c) {
    case 'u':  //Forward
      UP();
      break;
    case 'l':  //Turn Left
      Left();
      break;
    case 'r':  //Turn Right
      Right();
      break;
    default:
     Serial.println("no");
      break;
  }
}
void UP()
{
  analogWrite(11, pwn);
  analogWrite(3, pwn);
   digitalWrite(10, HIGH);=
  digitalWrite(9, LOW);
  digitalWrite(5, LOW);
  digitalWrite(4, HIGH);
  delay(850);
   motorstop();
}
void Right()
{
  analogWrite(11, pwn);
  analogWrite(3, pwn);
  digitalWrite(10, HIGH);
  digitalWrite(9, LOW);
  digitalWrite(5, LOW);
  digitalWrite(4,  LOW);
  delay(300);
  motorstop(); 
}
void Left()
{
  analogWrite(11, pwn);
  analogWrite(3, pwn);
  digitalWrite(10, LOW);
  digitalWrite(9, LOW);
  digitalWrite(5, LOW);
  digitalWrite(4,  HIGH);
  delay(300);
  motorstop(); 
}
void motorstop()
{
  // 馬達停止
  digitalWrite(10, LOW);
  digitalWrite(9, LOW);
  digitalWrite(5, LOW);
  digitalWrite(4, LOW);
  delay(1000);
}
