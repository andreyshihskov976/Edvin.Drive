namespace Edvin.Drive
{
    public class MySqlQueries
    {
        //Select
        public string Select_Avtopark = $@"SELECT avtopark.ID_Avto, avtopark.Marka AS 'Марка', avtopark.Model AS 'Модель', avtopark.Categoria_Avto AS 'Категория авто',
price.Name AS 'Пакет', avtopark.Gos_Znak AS 'Гос. знак', avtopark.VIN_Nomer AS 'VIN номер' 
FROM avtopark INNER JOIN price ON avtopark.ID_Price = price.ID_Price;";

        public string Select_Clienty = $@"SELECT clienty.ID_Clienta, CONCAT(clienty.Familiya, ' ', clienty.Imya, ' ', clienty.Otchestvo) AS 'Ф.И.О. Клиента',
clienty.Telephone AS 'Контактный телефон', clienty.Email AS 'Адрес электронной почты', 
CONCAT(clienty.Ser_Pass, ' ', clienty.Nom_Pass) AS 'Номер паспорта', clienty.Ident_Nom AS 'Идентификационный номер'
FROM clienty;";

        public string Select_Dogovory = $@"SELECT dogovory.ID_Dogovora, CONCAT(sotrudniki.Familiya,' ',sotrudniki.Imya,' ',sotrudniki.Otchestvo) AS 'Ф.И.О. Сотрудника',
CONCAT(clienty.Familiya, ' ', clienty.Imya, ' ', clienty.Otchestvo) AS 'Ф.И.О. Клиента',
dogovory.N_Arendy AS 'Дата начала аренды', dogovory.K_Arendy AS 'Дата окончания аренды',dogovory.Summa AS 'Сумма',
CONCAT(avtopark.Marka,' ',avtopark.Model,' ',avtopark.Gos_Znak) AS 'Автомобиль'
FROM dogovory INNER JOIN avtopark ON dogovory.ID_Avto = avtopark.ID_Avto
INNER JOIN clienty ON clienty.ID_Clienta = dogovory.ID_Clienta
INNER JOIN sotrudniki ON sotrudniki.ID_Sotrudnika = dogovory.ID_Sotrudnika;";

        public string Select_Doljnosti = $@"SELECT doljnosti.ID_Dojnosti, doljnosti.Name AS 'Наименование должности'
FROM doljnosti;";

        public string Select_Prava = $@"SELECT CONCAT(clienty.Familiya, ' ', clienty.Imya, ' ', clienty.Otchestvo) AS 'Ф.И.О. Клиенты',
prava.Nom_VodPrav AS 'Номер В/У', prava.AM AS 'АМ', prava.A1 AS 'А1', prava.A AS 'А', prava.B AS 'B',
prava.BE AS 'BE', prava.C AS 'CE', prava.D AS 'D', prava.DE AS 'DE'
FROM prava INNER JOIN clienty ON prava.ID_Clienta = clienty.ID_Clienta;";

        public string Select_Price = $@"SELECT price.ID_Price, price.Name AS 'Наименование пакета', price.Stoimost AS 'Стоимость', price.Skidka AS 'Скидка'
FROM price;";

        public string Select_Sotrudniki = $@"SELECT sotrudniki.ID_Sotrudnika, CONCAT(sotrudniki.Familiya,' ',sotrudniki.Imya,' ',sotrudniki.Otchestvo) AS 'Ф.И.О. Сотрудника',
doljnosti.Name AS 'Наименование должности', sotrudniki.Telephone AS 'Контактный телефон'
FROM sotrudniki INNER JOIN doljnosti ON sotrudniki.ID_Sotrudnika = doljnosti.ID_Dojnosti;";

        public string Select_Act_Sdachi = $@"SELECT acts.ID_Act, acts.Date AS 'Дата документа', acts.ID_Dogovora AS 'Договор аренды, №',
CONCAT(sotrudniki.Familiya,' ',sotrudniki.Imya,' ',sotrudniki.Otchestvo) AS 'Ф.И.О. Сотрудника',
CONCAT(avtopark.Marka,' ',avtopark.Model,' ',avtopark.Gos_Znak) AS 'Автомобиль'
FROM acts INNER JOIN sotrudniki ON acts.ID_Sotrudnika = sotrudniki.ID_Sotrudnika
INNER JOIN dogovory ON acts.ID_Dogovora = dogovory.ID_Dogovora
INNER JOIN avtopark ON acts.ID_Avto = avtopark.ID_Avto
WHERE acts.Name = '1';";

        public string Select_Act_Priemki = $@"SELECT acts.ID_Act, acts.Date AS 'Дата документа', acts.ID_Dogovora AS 'Договор аренды, №',
CONCAT(sotrudniki.Familiya,' ',sotrudniki.Imya,' ',sotrudniki.Otchestvo) AS 'Ф.И.О. Сотрудника',
CONCAT(avtopark.Marka,' ',avtopark.Model,' ',avtopark.Gos_Znak) AS 'Автомобиль'
FROM acts INNER JOIN sotrudniki ON acts.ID_Sotrudnika = sotrudniki.ID_Sotrudnika
INNER JOIN dogovory ON acts.ID_Dogovora = dogovory.ID_Dogovora
INNER JOIN avtopark ON acts.ID_Avto = avtopark.ID_Avto
WHERE acts.Name = '0';";
        //Select

        //Insert
        public string Insert_Doljnosti = $@"INSERT INTO doljnosti (Name) VALUES (@Value1);";
        //Insert
    }
}