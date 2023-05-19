# StaffProject

## InıtıalizeMigration dosyasını migrate edebilmek için :

StaffProject dizini içerisinde aşağıdaki komutunu çalıştırınız

` dotnet ef database update --project "./StaffProject.Data" --startup-project "./StaffProject" ` 


## Temel özellikler :
-Veri ekleme sırasında validation ile email alanının formatını ve empty durumunu kontrol eder.

-Put ve post methodlarında kullanılan emailin, veritabanında mevcut olup olmadığını kontrol eder.

-First Name ve City degerlerine göre filtreleme yapar. (getBy..)

## Gereksinimler :
-Sql database 

