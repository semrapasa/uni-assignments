hayvan_kontrol(kedi,Durum):-
    writeln('Gerçekleştirmek istediğiniz işlem nedir (mama,saglik)'),
    read(Islem),
    islem_menusu(kedi,Islem,Durum),
    !.
hayvan_kontrol(kopek,Durum):-
    writeln('Gerçekleştirmek istediğiniz işlem nedir (mama,saglik)'),
    read(Islem),
    islem_menusu(kopek,Islem,Durum),
    !.
hayvan_kontrol(_,yanlis_tür):-
    format('Henüz sistemimiz bu canlı türünü desteklememektedir'),nl,
    format('Desteklenen Türler: (kedi,kopek)'),nl,
    !.

islem_menusu(kedi,mama,Durum):-
    writeln('Son mama saati kaç saat önceydi???'),
    read(Saat),
    besleme(kedi,Saat,Durum).
islem_menusu(kedi,saglik,Durum):-
    writeln('Kedide halsizlik var mı?? (evet,hayir)'),
    read(Belirti),
    teshis_sistemi(kedi,Belirti,Durum).
islem_menusu(kopek,mama,Durum):-
    writeln('Son mama saati kaç saat önceydi???'),
    read(Saat),
    besleme(kopek,Saat,Durum).
islem_menusu(kopek,saglik,Durum):-
    writeln('Köpekte kaşıntı var mı?? (evet,hayir)'),
    read(Belirti),
    teshis_sistemi(kopek,Belirti,Durum).

teshis_sistemi(kedi,hayir,kediniz_oldukca_saglikli).
teshis_sistemi(kedi,evet,Durum):-
    write('Halsizlik ne seviyede??? (az,cok)'),
    read(Halsizlik),
    tedavi(kedi,Halsizlik,Durum).
teshis_sistemi(kopek,hayir,kopeginiz_oldukca_saglikli).
teshis_sistemi(kopek,evet,Durum):-
    write('Kaşıntı ne seviyede??? (az,cok)'),
    read(Kasinti),
    tedavi(kopek,Kasinti,Durum).

tedavi(kedi,az,mamasini_kontrol_edin).
tedavi(kedi,cok,acil_randevu).
tedavi(kopek,az,dis_parazit_uygulamasi).
tedavi(kopek,cok,acil_randevu).


besleme(kedi,Saat,besleme_vakti_gelmiş):-
    Saat>=6.
besleme(kedi,Saat,henuz_beslemeyiniz):-
    Saat<6,
    Kalan is 6-Saat,
    format('beslemeye kalan süre: ~w saat',[Kalan]),nl.
besleme(kopek,Saat,besleme_vakti_gelmiş):-
    Saat>=12.
besleme(kopek,Saat,henuz_beslemeyiniz):-
    Saat<12,
    Kalan is 12-Saat,
    format('beslemeye kalan süre: ~w saat',[Kalan]),nl.
basla:-
    repeat,
    format('---BU UYGULAMA BİR DÖNGÜYLE ÇALIŞMAKTADIR. SORGUYA DEVAM İÇİN BİR SAYI, BİTİRMEK İÇİN 0 GİRİNİZ---'),
    read(X),
    (   X=0->  !,format('---ÇIKIŞ YAPTINIZ---')
    ;
    writeln('Hayvan Türünü Giriniz (kedi,kopek)'),
    read(Tur),
    hayvan_kontrol(Tur,Durum),
    writeln(Durum),
    fail).