# HardwareMonitor_OnArduino
此系統可以讀取電腦硬體的使用狀態及參數，並顯示在一小塊TFT螢幕上。

## 系統架構
- 電腦端 
    一個C#編寫的小程式運用 [AIDA64](https://www.aida64.com/) 內提供的 Shared Memory 功能讀取系統硬體的相關訊息之後透過 Serial Port 傳送至 Arduino 做顯示。

- Arduino端 
    一塊 Arduino Nano 用作資料接收及解碼並驅動一塊 ILI9486 TFT 全彩3.5吋螢幕做顯示用。
    

## 目前發現的問題
1.單靠 USB5V 供電似乎有些不夠在螢幕刷新及資料運算時螢幕會出現亮度下降的問題。  
2.C# 程式在顯示硬體資料的區塊，在資料更新時會閃爍，這代表GUI的刷新邏輯還須改進。  
3.C# 程式得GUI不會隨著視窗大小變動而變化。
