EN ÇOK KULLANILAN YAZILIM MİMARİLERİ
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Yazılım kodlarınızın her bölümünü en iyi mimari ile optimize etmek için tek bir sistemde birden fazla kalıbı kullanabilir.

1) Katmanlı (n-katmanlı) mimari
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
Bu yaklaşım muhtemelen en yaygın olanıdır. Java EE, Drupal ve Express gibi en büyük ve en iyi yazılım çerçevelerinin çoğu, bu yapı göz önüne alındığında inşa edildiğinden, onlarla oluşturulan pek çok uygulama doğal olarak katmanlı bir mimaride ortaya çıkmaktadır.

Popüler web çerçevelerinin çoğunun sunduğu standart yazılım geliştirme yaklaşımı olan Model-View-Controller(MVC) yapısı açıkça katmanlı bir mimaridir.
Katmanlı mimaride uygulamalar ayrı katmanlar halinde yazıldığından, yönetilebilmesi ve  değiştirilmesi oldukça kolay ve hızlıdır.

* Presentation Layer : Yapılan uygulamanın kullanıcı arayüzüne ait projeler bu katmanda oluşturulur.
* Business Layer : Uygulamanın iş mantığı, Veritabanına ait oprasyonel(CRUD) işlemler , kullanıcı rolleri tanımlanır.
* Data Access Layer :  Sadece Veritabanına erişimi sağlamakla sorumlu katmandır.Her veritabanı için ayrı bir veriye erişim sınıfını içerebilir.


```c++
int main() {
    double a,b;
    cout << "Birinci Sayi : ";
    cin >> a;
    cout << "Ikinci Sayi : ";
    cin >> b;
    cout << "Toplam : " << a+b;
    system("PAUSE");
    return 0;
}
```


WARNING: Yazılımlarda katman sayısı arttıkça performans düşer.

CAUTION: Yönetim zorlaşır.

IMPORTANT: Büyük bir sistemde ağ güvenliğini yönetmek zor olabilir.


.Dünyada En Çok Kullanılan Programlama Dilleri
[width="100%",options="header,footer"]
|====================
| 1 |%90|  Java
| 2 |%80|Python
| 3 |%70|JavaScript
| 2 |%60|C++ 
| 3 |%50|c#
|====================


image::https://github.gallerycdn.vsassets.io/extensions/github/vscode-pull-request-github/0.4.0/1549568526519/Microsoft.VisualStudio.Services.Icons.Default[GithuB]

video::Gs8wX7VyAgw[youtube]

link:https://docs.microsoft.com/tr-tr/azure/architecture/guide/architecture-styles/n-tier[Kaynakça]
