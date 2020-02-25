#include <MCUFRIEND_kbv.h>
#include <Adafruit_GFX.h>
//#include <SD.h>
//lcd pin
#define LCD_RESET A4
#define LCD_CS A3
#define LCD_CD A2
#define LCD_WR A1
#define LCD_RD A0
//color
#define BLACK 0xFFFF
#define RED   0x07FF
#define GREEN 0xF81F
#define BLUE  0xFFE0
#define WHITE 0x0000
#define GRAY  0x1111
MCUFRIEND_kbv tft; //LCD ili9486



#include <Wire.h> 
String input;
int data[]={0,0,0,0,0,0,0,0,0,0,0};//[0]=cpu util [1]=cpu temp  [2]=gpu clock  [3]=gpu util
                                   //[4]=gpu temp [5]=vram util [6]=vram used  [7]=vram total
                                   //[8]=ram util [9]=ram used  [10]=ram total
int last_data[]={0,0,0,0,0,0,0,0,0,0,0};
void setup() {
  Serial.begin(115200);
  Serial.setTimeout(500);
  tft.reset();
  tft.begin(tft.readID());
  tft.invertDisplay(true);
  int x,y;
  for(x=0;x<320;x+=10){
    tft.drawLine(x,0,x,480,GREEN);
    }
   for(y=0;y<480;y+=10){
    tft.drawLine(0,y,320,y,GREEN);
   }
  printstruct();
}

void loop() {
  if(Serial.available()>0){
    int temp,flag=0,dataflag=0;
    input=Serial.readString();
    for(temp=0;temp<input.length();temp++){
      if(input.charAt(temp)==',')
        data[flag] = input.substring(dataflag,temp).toInt();
        dataflag = temp+1;
        flag++;
    }
  }     
}

void dataupdate(){
 if(data[0]!= last_data[0])
  BarUpdate(40,0,data[0],last_data[0]);
 if(data[1]!= last_data[1])
  BarUpdate(72,0,data[1],last_data[1]);
 if(data[2]!= last_data[2])
  WordUpdate(90,160,45,String(data[2]));
 if(data[3]!= last_data[3])
  BarUpdate(190,0,data[3],last_data[3]);
 if(data[4]!= last_data[4])
  BarUpdate(222,0,data[4],last_data[4]);
 if(data[5]!= last_data[5])
  BarUpdate(222,0,data[5],last_data[5]);
 if(data[6]!= last_data[6])
  WordUpdate(90,160,110,(String(data[6])+"/"+String(data[7])));
 if(data[8]!= last_data[8])
  BarUpdate(222,0,data[8],last_data[8]);
 if(data[9]!= last_data[9])
  WordUpdate(90,160,130,(String(data[9])+"/"+String(data[10])));
}

void BarUpdate(int posi,int bar_size,int data,int lastdata){//bar_size 0 = cpu gpu : 1 = ram posi in y
  switch(bar_size){
    case 0:
    if(data>lastdata){
      tft.fillRect(60+(lastdata*2),posi,(data-lastdata)*2,13,GREEN);
    }else{
      tft.fillRect(60+(data*2),posi,(lastdata-data)*2,13,BLACK);
    }
    tft.fillRect(270,posi,33,15,BLACK)
    tft.setCursor(270,posi);
    tft.print(data);
    break;
    case 1:
    if(data>lastdata){
      tft.fillRect(30+(lastdata*2),posi,((data-lastdata)*2),13,GREEN);
    }else{
      tft.fillRect(30+(data*2),posi,((lastdata-data)*2),13,BLACK);
    }
    tft.fillRect(255,posi,33,15,BLACK)
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
  tft.setCursor(140,0);
  tft.setTextSize(3); 
  tft.println("CPU");
  tft.setTextSize(2);
  tft.println("\nUtil:");
  tft.fillRect(60,40,200,13,RED);//CPU Util REC
  tft.setCursor(270,40);
  tft.print("100%\n");
  tft.println("\nTemp:");
  tft.fillRect(60,72,200,13,RED);//CPU TEMP REC
  tft.setCursor(270,72);
  tft.print("100C\n");
  //========== GPU ===============
  tft.setTextSize(3);
  tft.setCursor(140,120); 
  tft.println("GPU");
  tft.setTextSize(2);
  tft.println("\nClock: 1000 MHz");
  tft.println("\nUtil:");
  tft.fillRect(60,190,200,13,RED);//GPU Util REC
  tft.setCursor(270,190);
  tft.print("100%\n");
  tft.println("\nTemp:");
  tft.fillRect(60,222,200,13,RED);//GPU TEMP REC
  tft.setCursor(270,222);
  tft.print("100C\n");
  //========== VRAM ===============
  tft.setTextSize(3); 
  tft.setCursor(130,240);
  tft.println("VRAM");
  tft.setTextSize(2);
  tft.println("\n Used/Total:");
  tft.fillRect(30,310,200,13,RED);//VRAM Util REC
  tft.setCursor(255,310);
  tft.print("100%\n");
  tft.setCursor(100,330);//VRAM USED
  tft.setTextSize(2);
  tft.print("1000/1000 MB");
  //========== RAM ===============
  tft.setTextSize(3); 
  tft.setCursor(90,360);
  tft.println("RAM");
  tft.setTextSize(2);
  tft.println("\n Used/Total:");
  tft.fillRect(30,430,200,13,RED);//RAM Util REC
  tft.setCursor(255,430);
  tft.print("100%\n");
  tft.setCursor(80,450);//RAM USED
  tft.setTextSize(2);
  tft.print("10000/10000 MB");
}
