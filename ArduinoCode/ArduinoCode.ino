#include <Wire.h> 
#include <LiquidCrystal_I2C.h>
#define ARRAYSIZE 2
LiquidCrystal_I2C lcd(0x27, 16, 2);
String input,DataType,Data;
long previoustime=0,timenow,updatetime=1000;

void setup() {
  Serial.begin(115200);
  Serial.setTimeout(500);
  lcd.begin();
}

void loop() {
  
  if(Serial.available()>0){
    input=Serial.readString();
    dataprocess();
  }     
  timenow = millis();
  if(timenow-previoustime>updatetime){
    dataprint();
  }
}

void dataprocess(){
  int flag=0,stringcount=0;  

  if(input.indexOf("]") != -1){
      switch(input.substring(1,input.indexOf("]"))){
        case "UpdatetimeChange":
          updatetime = input.substring(input.indexOf("]"),(input.length()-1)).toInt();
          break;
        case "data":
          Data = input.substring(input.indexOf("]"),(input.length()-1));
          break;
      }
  }
}

void dataprint(){
  lcd.clear();
  lcd.setCursor(0,0);
  lcd.print(Data);
}
