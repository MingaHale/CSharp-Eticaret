//JavaScript'teki metotların ismi functiondur.
//javaScriptte sadecevar isminde değişken vardır.
//JavaScript HTML ile etkileşime geçmemizi sağlar
//ajax ise javascript ile aldığımız dataları C# tarafına göndermemizi sağlar
function JSSepeetEkle(AlinanId) {
    $.ajax({
        type: "POST", //İşlemin hangi http protokolünü kullanacağını belirtiyoruz
        url: "/JsonSepet/Insert", //datalar hangi adrese gidecektir
        data: { AlinanId: '' + AlinanId +''},//hangi fatalar gönderilecektir
        dataType: "json", //gönderilen datalar hangi türde gidecek
        success: function () {
            alert("İşlem Başarılı"); //Eğer işlem doğru bir şekilde gerçekleştiyse burası çalışacak
        },
        error: function () {
            alert("İşlem Başarısız"); //Eğer işlem yanlış bir şekilde gerçekleştiyse burası çalışacak
        }

    });
};
function JSSepetSil(AlinanId) {
    $.ajax({
        type: "POST", //İşlemin hangi http protokolünü kullanacağını belirtiyoruz
        url: "/JsonSepet/Delete", //datalar hangi adrese gidecektir
        data: { AlinanId: '' + AlinanId + '' },//hangi fatalar gönderilecektir
        dataType: "json", //gönderilen datalar hangi türde gidecek
        success: function () {
           location.reload(); //Eğer işlem doğru bir şekilde gerçekleştiyse burası çalışacak
        },
        error: function () {
            alert("İşlem Başarısız"); //Eğer işlem yanlış bir şekilde gerçekleştiyse burası çalışacak
        }

    });
};
function JSSepetAdet(AlinanId,islem) {
    $.ajax({
        type: "POST", 
        url: "/JsonSepet/AdetIslem", 
        data: { AlinanId: '' + AlinanId + '', islem: '' + islem + '' },
        dataType: "json", 
        success: function (response) {
            alert(response);
            location.reload(); 
        },
        error: function () {
            alert("İşlem Başarısız"); 
        }

    });
};
