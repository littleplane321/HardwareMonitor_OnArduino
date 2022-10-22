#include <MCUFRIEND_kbv.h>
#include <Adafruit_GFX.h>
#include <Arduino_JSON.h>
//lcd pin
#define LCD_RESET A4
#define LCD_CS A3
#define LCD_CD A2
#define LCD_WR A1
#define LCD_RD A0
//color
//#include <SD.h>
#define BLACK 0xFFFF
#define RED   0x07FF
#define GREEN 0xF81F
#define BLUE  0xFFE0
#define WHITE 0x0000
#define GRAY  0x1111
MCUFRIEND_kbv tft; //LCD ili9486



#include <Wire.h> 
String input;
int data[]={0,65,950,40,0,50,410,100,1000,3277,10,1000,1000,10};//[0]=cpu util  [1]=cpu temp  [2]=cpu clock [3]=cpu power
                                                                //[4]=gpu util  [5]=gpu temp  [6]=gpu clock [7]=gpu power  
                                                                //[8]=vram used [9]=vram free [10]=vram util[11]=ram used
                                                                //[12]=ram free [13]=ram util
int last_data[]={100,100,100,100,100,100,100,100,100,100,100,100,100,100};
int flag=0;
int util = 0;
bool updatefinish = true;
   
void setup() {
  Serial.begin(115200);
  Serial.setTimeout(500);
  tft.reset();
  tft.begin(tft.readID());
  tft.invertDisplay(true);
  int x,y;
  tft.fillScreen(BLACK);
  printstruct();
  pinMode(13,OUTPUT);
}

void loop() {
  if(Serial.available()>0){
    input=Serial.readStringUntil(':');
      data[(input.toInt())] = Serial.readStringUntil(',').toInt();
      dataupdate(input.toInt());
  }   
  
}

void dataupdate(int flag){
  switch(flag){
    case 0:
      if(data[0]!= last_data[0]&&data[0]!=0){
        BarUpdate(72,0,data[0],last_data[0]);
        last_data[0] = data[0];}
    break;
    case 1:
      if(data[1]!= last_data[1]){
        BarUpdate(100,0,data[1],last_data[1]);
        last_data[1] = data[1];}
    break;
    case 2:
      if(data[2]!= last_data[2]){
        WordUpdate(80,40,55,String(data[2])); 
        last_data[2] = data[2];}
    break;
    case 3:
      if(data[3]!= last_data[3]){
        WordUpdate(195,40,55,String(data[3])+"W"); 
        last_data[3] = data[3];}
    break;
    case 4:
      if(data[4]!= last_data[4]){
        BarUpdate(190,0,data[4],last_data[4]);
        last_data[4] = data[4];}
    break;
    case 5:
    if(data[5]!= last_data[5]){
      BarUpdate(222,0,data[5],last_data[5]);
      last_data[5] = data[5];}
    break;
    case 6:
      if(data[6]!= last_data[6]){
        WordUpdate(80,160,55,String(data[6]));
        last_data[6] = data[6];}
    break;    
    case 7:
      if(data[7]!= last_data[7]){
        WordUpdate(185,160,55,String(data[7])+"W"); 
        last_data[7] = data[7];}
    break;
    case 9:
      WordUpdate(100,330,110,(String(data[8])+"/"+String(data[9]+data[8])+"MB"));
      last_data[8] = data[8];
      last_data[9] = data[9];
    break;
    case 10:
      if(data[10]!= last_data[10]){
        BarUpdate(310,1,data[10],last_data[10]);
        last_data[10] = data[10];}
    break;       

    case 11:
      WordUpdate(120,450,130,(String(data[10])+"/"+String(data[10]+data[11])+"GB"));
      last_data[10] = data[10];
      last_data[11] = data[11];
    break;
    case 13:
      if(data[13]!= last_data[13]){
        BarUpdate(430,1,data[13],last_data[13]);
        last_data[13] = data[13];}
    break;    
    default:
    break;
    }
}

void BarUpdate(int posi,int bar_size,int data,int lastdata){//bar_size 0 = cpu,gpu  1 = ram , posi in y
  switch(bar_size){
    case 0:
    if(data>lastdata){
      tft.fillRect(60+(lastdata*2),posi,(data-lastdata)*2,13,GREEN);
    }else{
      tft.fillRect(60+(data*2),posi,(lastdata-data)*2,13,BLACK);
    }
    tft.fillRect(270,posi,35,15,BLACK);
    tft.setCursor(270,posi);
    tft.print(data);
    break;
    case 1:
    if(data>lastdata){
      tft.fillRect(30+(lastdata*2),posi,((data-lastdata)*2),13,GREEN);
    }else{
      tft.fillRect(30+(data*2),posi,((lastdata-data)*2),13,BLACK);
    }
    tft.fillRect(255,posi,35,15,BLACK);
    tft.setCursor(255,posi);
    tft.print(data);
    break; 
  }
}

void WordUpdate(int posi_x,int posi_y,int _size,String data){
  tft.fillRect(posi_x,posi_y,_size,15,BLACK);
  tft.setCursor(posi_x,posi_y);
  tft.print(data);
}


void printstruct(){
  //========== CPU ===============
  tft.setTextColor(WHITE);
  tft.setCursor(140,0);
  tft.setTextSize(3); 
  tft.println("CPU");
  tft.setTextSize(2);
  tft.println("\nClock: 1000 MHz");
  tft.println("\nUtil:");
  tft.fillRect(60,72,200,13,GREEN);//CPU Util REC
  tft.setCursor(270,72);
  tft.print("100%\n");
  tft.println("\nTemp:");
  tft.fillRect(60,100,200,13,GREEN);//CPU TEMP REC
  tft.setCursor(270,100);
  tft.print("100C\n");
  //========== GPU ===============
  tft.setTextSize(3);
  tft.setCursor(140,120); 
  tft.println("GPU");
  tft.setTextSize(2);
  tft.println("\nClock: 1000 MHz");
  tft.println("\nUtil:");
  tft.fillRect(60,190,200,13,GREEN);//GPU Util REC
  tft.setCursor(270,190);
  tft.print("100%\n");
  tft.println("\nTemp:");
  tft.fillRect(60,222,200,13,GREEN);//GPU TEMP REC
  tft.setCursor(270,222);
  tft.print("100C\n");
  //========== VRAM ===============
  tft.setTextSize(3); 
  tft.setCursor(130,240);
  tft.println("VRAM");
  tft.setTextSize(2);
  tft.println("\n Used/Total:");
  tft.fillRect(30,310,200,13,GREEN);//VRAM Util REC
  tft.setCursor(255,310);
  tft.print("100%\n");
  tft.setCursor(100,330);//VRAM USED
  tft.setTextSize(2);
  tft.print("1000/1000 MB");
  //========== RAM ===============
  tft.setTextSize(3); 
  tft.setCursor(130,360);
  tft.println("RAM");
  tft.setTextSize(2);
  tft.println("\n Used/Total:");
  tft.fillRect(30,430,200,13,GREEN);//RAM Util REC
  tft.setCursor(255,430);
  tft.print("100%\n");
  tft.setCursor(120,450);//RAM USED
  tft.setTextSize(2);
  tft.print("00/00 GB");
}
