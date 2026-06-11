#include<stdio.h>
#include<graphics.h>
#include<conio.h>
#include<dos.h>
#include<stdlib.h>
#include<bios.h>
#include<time.h>
//veritabani ve while cok hata veriyordu,onlari daha yeni calistirmayi basardim,ekle ve sil komutlarini
//yetistiremedim ama ekliycem
//tek bir txt kullandim adi randev.txt bin klasorunde kayitli ve icinde 100 yazdim
void hastane()
{
cleardevice();
srand(time(NULL));
int hastane=rand()%3;
if(hastane==0)
{
outtextxy(150,150,"SIZE EN YAKIN HASTANEMIZ");
outtextxy(165,170,"HATAY PATI PARK");
delay(4000);
closegraph();
}
if(hastane==1)
{
outtextxy(150,150,"SIZE EN YAKIN HASTANEMIZ");
outtextxy(165,170,"ISTANBUL HAYVAN ACILI");
delay(4000);
closegraph();
}
if(hastane==2)
{
outtextxy(150,150,"SIZE EN YAKIN HASTANEMIZ");
outtextxy(165,170,"SINOP PATI HASTANESI");
delay(4000);
closegraph();
}
}
void randevu()
{FILE *r;
r=fopen("C:\\TURBOC3\\BIN\\randev.txt","r");
int randevusayisi;
fscanf(r,"%d",&randevusayisi);
fclose(r);
union REGS i,o;
int x1,y1,tikla;
i.x.ax=1;
int86(0x33,&i,&o);
i.x.ax=3;
cleardevice();
setcolor(CYAN);
setbkcolor(DARKGRAY);
setfillstyle(SOLID_FILL,LIGHTCYAN);
rectangle(getmaxx()/2-100,getmaxy()/2-30,getmaxx()/2+100,getmaxy()/2+30);
floodfill(getmaxx()/2-90,getmaxy()/2-25,CYAN);
setcolor(BLACK);
settextstyle(1,0,1);
outtextxy(getmaxx()/2-60,getmaxy()/2-10,"RANDEVU AL");
while(!kbhit())
{
x1=o.x.cx;
y1=o.x.dx;
int86(0x33,&i,&o);
tikla=o.x.bx&7;
if((x1>=(getmaxx()/2-100)&&x1<=(getmaxx()/2+100))&&(y1>=(getmaxy()/2-30)&&y1<=(getmaxy()/2+30)))
{
if(tikla==1)
{
randevusayisi=randevusayisi-1;
r=fopen("C:\\TURBOC3\\BIN\\randev.txt","w");
fprintf(r,"%d",randevusayisi-1);
fclose(r);
closegraph();
}
}
}
}
void ekran()
{cleardevice();
settextstyle(0,0,2);
outtextxy(240,100,"HOSGELDINIZ");
setcolor(WHITE),
rectangle(getmaxx()/2-50,150,getmaxx()/2+50,180);
rectangle(getmaxx()/2-50,185,getmaxx()/2+50,215);
rectangle(getmaxx()/2-50,220,getmaxx()/2+50,250);
rectangle(getmaxx()/2-50,255,getmaxx()/2+50,285);
settextstyle(2,0,5);
outtextxy(getmaxx()/2-44,160,"beslenme");
outtextxy(getmaxx()/2-44,195,"asi randevu");
outtextxy(getmaxx()/2-44,230,"kisirlastirma");
outtextxy(getmaxx()/2-44,265,"!!!ACIL!!!");
}
void doldur(int sec)
{
switch(sec)
{
case 1:
cleardevice();
ekran();
setcolor(GREEN);
setfillstyle(SOLID_FILL,GREEN);
rectangle(getmaxx()/2-50,150,getmaxx()/2+50,180);
floodfill(getmaxx()/2-45,160,GREEN);
setcolor(WHITE);
settextstyle(2,0,5);
outtextxy(getmaxx()/2-44,160,"beslenme");
break;
case 2:
cleardevice();
ekran();
setcolor(GREEN);
setfillstyle(SOLID_FILL,GREEN);
rectangle(getmaxx()/2-50,185,getmaxx()/2+50,215);
floodfill(getmaxx()/2-45,195,GREEN);
setcolor(WHITE);
settextstyle(2,0,5);
outtextxy(getmaxx()/2-44,195,"asi randevu/cip");
break;
case 3:
cleardevice();
ekran();
setcolor(GREEN);
setfillstyle(SOLID_FILL,GREEN);
rectangle(getmaxx()/2-50,220,getmaxx()/2+50,250);
floodfill(getmaxx()/2-44,230,GREEN);
setcolor(WHITE);
settextstyle(2,0,5);
outtextxy(getmaxx()/2-44,230,"kisirlastirma");
break;
case 4:
cleardevice();
ekran();
setcolor(GREEN);
setfillstyle(SOLID_FILL,GREEN);
rectangle(getmaxx()/2-50,255,getmaxx()/2+50,285);
floodfill(getmaxx()/2-45,270,GREEN);
setcolor(WHITE);
settextstyle(2,0,5);
outtextxy(getmaxx()/2-44,265,"!!!ACIL!!!");
break;
}}
int main()
{
int gd=DETECT,gm,tikla,x1,y1,sec=1,tus;
initgraph(&gd,&gm," ");
ekran();
while(1)
{tus=bioskey(0);
if(sec>4)
sec=1;
if (tus==20480) 
{cleardevice();
sec++;
if(sec>4)
sec=1;
doldur(sec);
}else if(tus==18432 ) 
{cleardevice();
sec--;
if(sec<1)
sec=4;
doldur(sec);
}
else if (tus==7181)
{
if(sec==4)
hastane();
else
randevu();
} 
}
getch();
closegraph();
return 0;
}