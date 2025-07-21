# Slot Match Puzzle

Bu doküman, seviyelere dayalı bir match3 türevi olarak tasarlanan **Slot Match Puzzle** oyun fikrinin özetini sunar. Klasik eşleştirme formülüne slot bar ve serbest sürükleme mekanikleri eklenmiştir. Amaç, sınırlı hamle sayısı içinde hedefleri tamamlamak ve yüksek puana ulaşmaktır.

## Oyun Mekanikleri

### Grid & Objeler
- Oyun alanında rastgele yerleştirilmiş farklı şekiller bulunur (kalp, kare, yıldız, daire, üçgen vb.).
- Grid boyutu seviye ilerledikçe değişebilir (6x6, 7x7, 8x8...).

### Slot Bar
- Gridin altında belirli sayıda slot barı vardır (örn. 7 slot).
- Griddeki herhangi bir objeye tıklandığında obje ilk boş slota gider.
- Slotlardaki taşlar sağa/sola sürüklenerek yer değiştirebilir.
- Bazı taşlar kilitli olabilir ve yerlerinden oynatılamaz.
- Slottaki taşlar istenirse orijinal konumlarına geri çağrılabilir.

### Eşleştirme ve Puanlama
- Yan yana 3 veya daha fazla aynı obje geldiğinde otomatik olarak eşleşir ve silinir.
- Tek hamlede birden çok eşleşme yapılırsa **combo** puanı alınır.
- 5'li veya daha büyük eşleşmeler ekstra skor ve özel animasyon kazandırır.

### Hamle Sistemi
- Her seviye belirli sayıda hamleyle başlar.
- Gridden obje seçmek ya da slotta sürükleme yapmak hamle harcar.
- Hamleler bitmeden hedefler tamamlanmazsa seviye kaybedilir.

### Görevler & Seviye Tasarımı
- "15 kırmızı topla", "3 defa 5'li eşleşme yap" gibi hedefler bulunur.
- Görevler bitince bir sonraki seviye açılır.
- Seviye ilerledikçe grid büyür ve kilitli taşlar gibi yeni engeller eklenir.

### Kaybetme / Kazanma
- Tüm görevler tamamlanırsa seviye geçilir.
- Hamleler biter ve görevler tamamlanmazsa seviye başarısız olur.

### Row Shift Mekaniği
- Eşleşme yapıldığında griddeki tüm satırlar bir aşağı kayar.
- En alttaki satırdan taşlar silinir, en üst satır yeni objelerle dolar.
- Böylece her hamlede grid tazelenir ve slot makinesi hissi oluşur.

## Oyun Akışı Kısa Özet
1. Seviye yüklenir ve grid oluşur.
2. Oyuncu gridden taş seçip slot bara gönderir, burada dizilişi değiştirir.
3. Eşleşmeler gerçekleştikçe puan toplanır ve satırlar kayar.
4. Hamle sayısı sıfırlanmadan hedefler tamamlanırsa seviye geçilir.

## Geliştirme Notları
- **Animasyon odaklı hareketler:** Taşların hareketleri ve slot bar kaymaları için animasyon kullanın. Animasyon bitişlerinde event tetikleyip oyun akışını kontrol edin.
- Sistemin animatif olması, özellikle "row shift" sırasında görsel geri bildirim sağlar.

