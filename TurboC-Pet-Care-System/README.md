<p align="center">
  
<img src="https://capsule-render.vercel.app/api?type=waving&amp;color=gradient&amp;customColorList=20,30,46,15,76,92&amp;height=220&amp;section=header&amp;text=Vet-Graph%20OS&amp;fontSize=56&amp;fontColor=fff&amp;animation=twinkling&amp;fontAlignY=40&amp;desc=Retro%20C%20Graphics%20%7C%20Veterinary%20Appointment%20System%20%7C%20Turbo%20C%2B%2B%20Compatible&amp;descAlignY=62&amp;descSize=16" />
<p align="center">
  <img src="[https://img.shields.io/badge/Language-C-A8B9CC?style=for-the-badge&logo=c&logoColor=black](https://img.shields.io/badge/Language-C-A8B9CC?style=for-the-badge&logo=c&logoColor=black)" />
  <img src="[https://img.shields.io/badge/Graphics-BGI%20(graphics.h)-FF5722?style=for-the-badge](https://img.shields.io/badge/Graphics-BGI%20(graphics.h)-FF5722?style=for-the-badge)" />
  <img src="[https://img.shields.io/badge/Environment-Turbo%20C%2B%2B%20%2F%20DOSBox-0052CC?style=for-the-badge&logo=dosbox&logoColor=white](https://img.shields.io/badge/Environment-Turbo%20C%2B%2B%20%2F%20DOSBox-0052CC?style=for-the-badge&logo=dosbox&logoColor=white)" />
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Status-Developped-yellow?style=flat-square" />
  <img src="https://img.shields.io/badge/License-MIT-green?style=flat-square" />
</p>

---

## 🐾 Proje Hakkında

**Vet-Graph OS**, Turbo C++ derleyicisi ve DOS ortamı için saf C diliyle geliştirdiğim, GUI temellerini görmek için yazdığım bir **Veteriner Randevu ve Acil Durum Yönetim Sistemi** simülasyonudur. 

Modern işletim sistemlerinin olmadığı dönemlerdeki düşük seviyeli (low-level) donanım yönetimini temel alır. Klavye yön tuşları (`bioskey`) ile menü navigasyonu sunar ve randevu onay işlemlerinde fare (mouse) kesmelerini (`interrupt 0x33`) aktif olarak kullanır.

---

## ⚡ Temel Özellikler

* **🕹️ İnteraktif Klavye Navigasyonu:** `bioskey(0)` fonksiyonu kullanılarak yukarı/aşağı yön tuşlarıyla menüler arasında dinamik geçiş ve yeşil renkli odaklanma (hover) efekti.
* **🖱️ Mouse Kesmesi (Interrupt 0x33) Desteği:** Randevu ekranında DOS seviyesinde fare imleci tetikleme ve sol tık algılama sistemi.
* **💾 Dosya Tabanlı Veritabanı:** Mevcut randevu kotasını `randev.txt` üzerinden dinamik olarak okuma ve güncel tutma.
* **🚨 Akıllı Acil Durum Modu:** `!!!ACIL!!!` seçeneğinde en yakındaki pati hastanesini (`srand` algoritmasıyla) otomatik olarak belirleme ve ekrana yazdırma.

---

## 🗺️ Menü Yapısı & Modlar

Sistem açıldığında kullanıcıyı 4 ana daldan oluşan bir işletim sistemi arayüzü karşılar:

| Menü Seçeneği | İşlev | Kullandığı Teknoloji |
| :--- | :--- | :--- |
| **Beslenme** | Evcil hayvan beslenme randevusu | BGI Menü Yönetimi |
| **Aşı Randevu** | Aşı ve Çip işlemleri planlaması | BGI Menü Yönetimi |
| **Kısırlıklaştırma** | Kısırlıklaştırma randevu ekranı | BGI Menü Yönetimi |
| **🚨 !!!ACIL!!!** | En yakın hayvan hastanesi konumu | `time.h` & `rand()` Algoritması |

---



### 🎯 Proje Lojik Akış Şeması
Projenin çalışma mantığı, DOS alt yapısındaki sonsuz döngü (`while(1)`) ve donanım kesmelerinin dinlenmesi üzerine kuruludur:

```mermaid
graph TD
    A[Program Başlatma: initgraph] --> B[Ana Ekranı Çiz: ekran]
    B --> C{Klavye Girdisi Bekle: bioskey}
    C -->|Yukarı / Aşağı Tuşları| D[Aktif Menüyü Değiştir & Yeşile Boya: doldur]
    C -->|Enter Tuşu| E{Seçim Nedir?}
    E -->|case 4: ACIL| F[Rastgele Hastane Ata: hastane]
    E -->|case 1, 2, 3| G[Randevu Ekranını Aç: randevu]
    G --> H{Mouse Sol Tıklandı mı?}
    H -->|Evet| I[randev.txt Veritabanını Güncelle ve Eksilt]
    I --> B
```

---

## 🚀 Çalıştırma Talimatları

Proje antik donanım kesmeleri ve `graphics.h` kütüphanesini kullandığı için doğrudan modern Windows/Linux/macOS terminalinde çalışmaz. Çalıştırmak için **Turbo C++** veya **DOSBox** emülatörüne ihtiyacınız vardır.

### DOSBox ve Turbo C++ ile Çalıştırma:

1.  **Veritabanı Hazırlığı:** `randev.txt` adında bir dosya oluşturun, içine `100` yazın ve bu dosyayı derleyicinizin `BIN` klasörüne yerleştirin (`C:\TURBOC3\BIN\randev.txt`).
2.  **Grafik Sürücüsü:** Kodun içindeki `initgraph(&gd,&gm," ");` kısmında, tırnak içine eğer gerekiyorsa BGI sürücünüzün yolunu verin (Örn: `"C:\\TURBOC3\\BGI"`).
3.  **Derleme:** Turbo C++ arayüzünde `F9` tuşuna basarak projeyi derleyin ve `Ctrl + F9` ile çalıştırın.

---

## 🎮 Kontrol Kılavuzu

* **`⬇️ Aşağı Ok Tuşu`** : Bir sonraki menü seçeneğine odaklanır.
* **`⬆️ Yukarı Ok Tuşu`** : Bir önceki menü seçeneğine odaklanır.
* **`⌨️ Enter Tuşu`** : Odaklanılmış olan menü fonksiyonunu tetikler.
* **`🖱️ Mouse Sol Tık`** : Randevu alma ekranında "RANDEVU AL" butonuna tıklandığında randevu sayısını düşürür.

---



<p align="center">
  <img src="[https://capsule-render.vercel.app/api?type=waving&color=gradient&customColorList=20,30,46,15,76,92&height=100&section=footer](https://capsule-render.vercel.app/api?type=waving&color=gradient&customColorList=20,30,46,15,76,92&height=100&section=footer)" />
</p>
