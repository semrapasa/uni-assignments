<p align="center">
  <img src="https://capsule-render.vercel.app/api?type=waving&amp;color=gradient&amp;customColorList=20,10,10&amp;height=220&amp;section=header&amp;text=Pet%20Care%20System&amp;fontSize=48&amp;fontColor=fff&amp;animation=twinkling&amp;fontAlignY=40&amp;desc=Prolog%20Expert%20System%20%7C%20Artificial%20Intelligence%20%7C%20SWI-Prolog&amp;descAlignY=62&amp;descSize=16" />
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Language-Prolog-74283c?style=for-the-badge&amp;logo=prolog&amp;logoColor=white" />
  <img src="https://img.shields.io/badge/Environment-SWI--Prolog-0052CC?style=for-the-badge" />
  <img src="https://img.shields.io/badge/Paradigm-Declarative%20%2F%20Rules-orange?style=for-the-badge" />
</p>

<p align="center">
  <img src="https://img.shields.io/badge/Status-In%20Development-yellow?style=flat-square" />
  <img src="https://img.shields.io/badge/License-MIT-green?style=flat-square" />
</p>

---


## 📡 Proje Nedir?

**Hayvan Bakım ve Tedavi Sistemi**, sisteme girilen canlı türüne (kedi veya köpek) ve kullanıcının belirttiği durumlara göre hayvanın ihtiyacı olan doğru bakımı veya sağlık sorunu tedavisini belirleyen bildirim tabanlı bir **Prolog Uzman Sistemidir**. 

Uygulamanın tamamı interaktif bir döngü (`repeat-fail`) mekanizması üzerinde çalışır; bu sayede kullanıcı programdan çıkış yapmadığı sürece peş peşe kesintisiz sorgulama yapabilir.

---

## ⚡ Sistem Kuralları ve Mantıksal Altyapı

Sistem, kullanıcı girdilerini deklaratif mantık kuralları süzgecinden geçirerek karara bağlar:

### 🥩 1. Besleme (Mama) Yönetimi
* **Kedi:** Son beslemeden itibaren **6 saat veya daha fazla** süre geçtiyse besleme vakti gelmiştir. 6 saatten az ise sonraki beslemeye kalan süre hesaplanır ve `henüz beslemeyin` uyarısı verilir.
* **Köpek:** Son beslemeden itibaren **12 saat veya daha fazla** süre geçtiyse besleme vakti gelmiştir. 12 saatten az ise kalan süre hesaplanarak `henüz beslemeyin` uyarısı döndürülür.

### 🩺 2. Teşhis ve Sağlık Sistemi
* **Kedi (Belirti: Halsizlik):**
  * Halsizlik Az ise $\rightarrow$ `Mamasını kontrol edin`
  * Halsizlik Çok ise $\rightarrow$ `Acil randevu`
  * Halsizlik Yoksa $\rightarrow$ `Kediniz oldukça sağlıklı`
* **Köpek (Belirti: Kaşıntı):**
  * Kaşıntı Az ise $\rightarrow$ `Dış parazit tedavisi`
  * Kaşıntı Çok ise $\rightarrow$ `Acil randevu`
  * Kaşıntı Yoksa $\rightarrow$ `Köpeğiniz oldukça sağlıklı`

---

## 🏗️ Karar Algoritması ve Bilgi Akışı



## 💻 Kaynak Kodları (`pet_care_system.pl`)

Aşağıda, prolog içeriğindeki mantıksal yapının tam fonksiyonel çalıştırılıp sonuç alınmış halini görüyorsunuz
```prolog



---

## 🕹️ Konsol Çalışma Senaryosu (Execution Output)

Sistemin SWI-Prolog ortamındaki çalışma simülasyon çıktısı tam olarak şu şekildedir:

```text
?- basla.

---BU UYGULAMA BİR DÖNGÜYLE ÇALIŞMAKTADIR. SORGUYA DEVAM İÇİN BİR SAYI, BİTİRMEK İÇİN 0 GİRİNİZ---
|: 1.
Hayvan Türünü Giriniz (kedi, kopek):
|: kedi.
Gerçekleştirmek istediğiniz işlem nedir (mama, saglik):
|: mama.
Son mama saati kaç saat önceydi???
|: 4.
Beslemeye kalan süre: 2 saat
henuz_beslemeyiniz

---BU UYGULAMA BİR DÖNGÜYLE ÇALIŞMAKTADIR. SORGUYA DEVAM İÇİN BİR SAYI, BİTİRMEK İÇİN 0 GİRİNİZ---
|: 1.
Hayvan Türünü Giriniz (kedi, kopek):
|: kedi.
Gerçekleştirmek istediğiniz işlem nedir (mama, saglik):
|: mama.
Son mama saati kaç saat önceydi???
|: 7.
besleme_vakti_gelmis

---BU UYGULAMA BİR DÖNGÜYLE ÇALIŞMAKTADIR. SORGUYA DEVAM İÇİN BİR SAYI, BİTİRMEK İÇİN 0 GİRİNİZ---
|: 1.
Hayvan Türünü Giriniz (kedi, kopek):
|: kopek.
Gerçekleştirmek istediğiniz işlem nedir (mama, saglik):
|: saglik.
Köpekte kaşıntı var mı?? (evet, hayir)
|: evet.
Kaşıntı ne seviyede??? (az, cok)
|: cok.
acil_randevu

---BU UYGULAMA BİR DÖNGÜYLE ÇALIŞMAKTADIR. SORGUYA DEVAM İÇİN BİR SAYI, BİTİRMEK İÇİN 0 GİRİNİZ---
|: 1.
Hayvan Türünü Giriniz (kedi, kopek):
|: tavsan.
Henüz sistemimiz bu canlı türünü desteklememektedir
Desteklenen Türler: (kedi, kopek)
yanlis_tur

---BU UYGULAMA BİR DÖNGÜYLE ÇALIŞMAKTADIR. SORGUYA DEVAM İÇİN BİR SAYI, BİTİRMEK İÇİN 0 GİRİNİZ---
|: 0.
---ÇIKIŞ YAPTINIZ---
true.
```

---

## 🛠️ Nasıl Çalıştırılır?

Bu projeyi bilgisayarınıza hiçbir şey indirmeden veya kurmadan, doğrudan internet tarayıcınız üzerinden **SWI-Prolog Online (SWISH)** kullanarak saniyeler içinde çalıştırıp test edebilirsiniz:

1. **SWI-Prolog Online'ı Açın:** Tarayıcınızdan **[swish.swi-prolog.org](https://swish.swi-prolog.org/)** adresine gidin.
2. **Boş Program Alanı Oluşturun:** Açılan ana ekrandaki **"Program"** (boş sayfa) seçeneğine tıklayın. Ekranın sol tarafında kod yazabileceğiniz boş bir editör alanı açılacaktır.
3. **Kodu Yapıştırın:** `prolog_odevi.pl` kaynak kod bloğunun tamamını kopyalayın ve sol taraftaki o boş editör alanına yapıştırın.
4. **Sistemi Başlatın:** Ekranın sağ alt tarafındaki sorgu (Query) satırına (`?-` işaretinin yanına) sadece şunu yazıp klavyeden **Enter**'a veya yanındaki **"Execute"** butonuna basın:
   ```prolog
   basla.
   ```

> **⚠️ SWISH İçin Çalışma Kuralları (Önemli Not):**
> * SWISH (Online sürüm) altyapısı gereği, interaktif `read/1` sorguları çalıştırıldığında girdilerinizi ekranın sağ tarafında açılacak olan **küçük kutucuğa (girdi alanına)** yazmanız gerekir.
> * Uygulama sizden bir sayı istediğinde (Döngüye devam etmek veya bitirmek için) girdinin sonuna mutlaka nokta koymalısınız: **`1.`** veya **`0.`**
> * Uygulama sizden metin tabanlı bir tür veya işlem istediğinde (kedi, kopek, mama, saglik, evet, hayir, az, cok) girdiyi mutlaka **küçük harfle** yazmalı ve sonuna **nokta (`.`)** koymalısınız. (Örn: **`kedi.`**, **`mama.`** veya **`evet.`**)
<p align="center">
  <img src="https://capsule-render.vercel.app/api?type=waving&amp;color=gradient&amp;customColorList=12,20,24&amp;height=100&amp;section=footer" />
</p>
