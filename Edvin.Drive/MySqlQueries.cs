namespace Edvin.Drive
{
    public class MySqlQueries
    {
        //Select
        public string Select_Avtopark = $@"SELECT avtopark.ID_Avto, avtopark.Marka AS 'Марка', avtopark.Model AS 'Модель', avtopark.Categoria_Avto AS 'Категория авто',
price.Name AS 'Пакет', avtopark.Gos_Znak AS 'Гос. знак', avtopark.VIN_Nomer AS 'VIN номер', avtopark.Stoimost AS 'Балансовая стоимость, $', avtopark.Identify AS 'Идентификатор'
FROM avtopark INNER JOIN price ON avtopark.ID_Price = price.ID_Price;";

        public string Select_Clienty = $@"SELECT clienty.ID_Clienta, CONCAT(clienty.Familiya, ' ', clienty.Imya, ' ', clienty.Otchestvo) AS 'Ф.И.О. Клиента',
clienty.Telephone AS 'Контактный телефон', clienty.Email AS 'Адрес электронной почты', 
clienty.Nom_Pass AS 'Номер паспорта', clienty.Ident_Nom AS 'Идентификационный номер'
FROM clienty;";

        public string Select_Dogovory = $@"SELECT dogovory.ID_Dogovora, dogovory.Date AS 'Дата заключения', CONCAT(sotrudniki.Familiya,' ',sotrudniki.Imya,' ',sotrudniki.Otchestvo) AS 'Ф.И.О. Сотрудника',
CONCAT(clienty.Familiya, ' ', clienty.Imya, ' ', clienty.Otchestvo) AS 'Ф.И.О. Клиента',
CONCAT(avtopark.Marka,' ',avtopark.Model,' ',avtopark.Gos_Znak) AS 'Автомобиль',
dogovory.N_Arendy AS 'Дата начала аренды', dogovory.K_Arendy AS 'Дата окончания аренды',dogovory.Summa AS 'Сумма',
dogovory.Identify AS 'Идентификатор'
FROM dogovory INNER JOIN avtopark ON dogovory.ID_Avto = avtopark.ID_Avto
INNER JOIN clienty ON clienty.ID_Clienta = dogovory.ID_Clienta
INNER JOIN sotrudniki ON sotrudniki.ID_Sotrudnika = dogovory.ID_Sotrudnika;";

        public string Select_Doljnosti = $@"SELECT doljnosti.ID_Doljnosti, doljnosti.Name AS 'Наименование должности'
FROM doljnosti;";

        public string Select_Prava = $@"SELECT prava.ID_Prav, CONCAT(clienty.Familiya, ' ', clienty.Imya, ' ', clienty.Otchestvo) AS 'Ф.И.О. Клиенты',
prava.Nom_VodPrav AS 'Номер В/У', prava.AM AS 'АМ', prava.A1 AS 'А1', prava.A AS 'А', prava.B AS 'B', prava.C AS 'C', prava.D AS 'D'
FROM prava INNER JOIN clienty ON prava.ID_Clienta = clienty.ID_Clienta;";

        public string Select_Price = $@"SELECT price.ID_Price, price.Name AS 'Наименование пакета', price.Stoimost AS 'Стоимость', price.Skidka AS 'Скидка'
FROM price;";

        public string Select_Sotrudniki = $@"SELECT sotrudniki.ID_Sotrudnika, CONCAT(sotrudniki.Familiya,' ',sotrudniki.Imya,' ',sotrudniki.Otchestvo) AS 'Ф.И.О. Сотрудника',
doljnosti.Name AS 'Наименование должности', sotrudniki.Telephone AS 'Контактный телефон'
FROM sotrudniki INNER JOIN doljnosti ON sotrudniki.ID_Doljnosti = doljnosti.ID_Doljnosti;";

        public string Select_Acts = $@"SELECT acts.ID_Act,acts.Name AS 'Вид акта', acts.Date AS 'Дата документа', acts.ID_Dogovora AS 'Договор аренды, №',
CONCAT(sotrudniki.Familiya,' ',sotrudniki.Imya,' ',sotrudniki.Otchestvo) AS 'Ф.И.О. Сотрудника',
CONCAT(avtopark.Marka,' ',avtopark.Model,' ',avtopark.Gos_Znak) AS 'Автомобиль'
FROM acts INNER JOIN sotrudniki ON acts.ID_Sotrudnika = sotrudniki.ID_Sotrudnika
INNER JOIN dogovory ON acts.ID_Dogovora = dogovory.ID_Dogovora
INNER JOIN avtopark ON acts.ID_Avto = avtopark.ID_Avto;";

        public string Select_Price_ComboBox = $@"SELECT price.Name FROM price;";

        public string Select_Price_ID = $@"SELECT price.ID_Price FROM price WHERE price.Name = @Value1;";

        public string Select_Doljnosti_ComboBox = $@"SELECT doljnosti.Name FROM doljnosti;";

        public string Select_Doljnosti_ID = $@"SELECT doljnosti.ID_Doljnosti FROM doljnosti WHERE doljnosti.Name = @Value1;";

        public string Select_Clienty_ComboBox = $@"SELECT CONCAT(clienty.Familiya, ' ', clienty.Imya, ' ', clienty.Otchestvo) FROM clienty;";

        public string Select_Clienty_ComboBoxIsNull = $@"SELECT DISTINCT CONCAT(clienty.Familiya, ' ', clienty.Imya, ' ', clienty.Otchestvo) FROM clienty
LEFT JOIN prava ON prava.ID_Clienta = clienty.ID_Clienta
WHERE prava.ID_Clienta IS NULL;";

        public string Select_Clienty_ID = $@"SELECT clienty.ID_Clienta FROM clienty WHERE CONCAT(clienty.Familiya, ' ', clienty.Imya, ' ', clienty.Otchestvo) = @Value1;";

        public string Select_Sotrudniki_ComboBox = $@"SELECT CONCAT(sotrudniki.Familiya, ' ', sotrudniki.Imya, ' ', sotrudniki.Otchestvo) FROM sotrudniki;";

        public string Select_Sotrudniki_ID = $@"SELECT sotrudniki.ID_Sotrudnika FROM sotrudniki WHERE CONCAT(sotrudniki.Familiya, ' ', sotrudniki.Imya, ' ', sotrudniki.Otchestvo) = @Value1;";

        public string Select_Avtopark_ComboBox = $@"SELECT CONCAT(avtopark.Marka, ' ',avtopark.Model,' ',avtopark.Gos_Znak) FROM avtopark;";

        public string Select_Avtopark_ID = $@"SELECT avtopark.ID_Avto FROM avtopark WHERE CONCAT(avtopark.Marka, ' ',avtopark.Model,' ',avtopark.Gos_Znak) = @Value1;";

        public string Select_Avto_Dogovora = $@"SELECT CONCAT(avtopark.Marka, ' ',avtopark.Model,' ',avtopark.Gos_Znak) 
FROM dogovory 
INNER JOIN avtopark ON dogovory.ID_Avto = avtopark.ID_Avto
WHERE CONCAT('№ ', dogovory.ID_Dogovora, ' от ', dogovory.Date) = @Value1;";

        public string Select_Dogovory_ComboBox = $@"SET lc_time_names = 'ru_RU'; SELECT CONCAT('№ ',dogovory.ID_Dogovora,' от ',DATE_FORMAT(dogovory.Date,'%d %M %Y')) FROM dogovory;";

        public string Select_Dogovory_ID = $@"SET lc_time_names = 'ru_RU'; SELECT dogovory.ID_Dogovora FROM dogovory WHERE CONCAT('№ ',dogovory.ID_Dogovora,' от ',DATE_FORMAT(dogovory.Date,'%d %M %Y')) = @Value1;";

        public string Select_Prava_Exists = $@"SELECT EXISTS(SELECT * FROM prava WHERE prava.ID_Clienta = @ID);";

        public string Select_Exists_Nedeistv_Dogovory = $@"SELECT EXISTS(SELECT * 
FROM dogovory WHERE dogovory.K_Arendy < CURDATE() AND dogovory.Identify = 'Действительный');";

        public string Select_List_Nedeistv_Dogovory = $@"SET lc_time_names = 'ru_RU';
SELECT CONCAT('№ ',dogovory.ID_Dogovora,' от ',DATE_FORMAT(dogovory.Date,'%d %M %Y')) 
FROM dogovory WHERE dogovory.K_Arendy < CURDATE() AND dogovory.Identify = 'Действительный';";

        public string Select_Stoimost = $@"SELECT price.Stoimost-price.Skidka/100 FROM price INNER JOIN avtopark ON avtopark.ID_Price = price.ID_Price WHERE avtopark.ID_Avto = @ID;";

        public string Select_ListAvto = $@"SELECT DISTINCT avtopark.ID_Avto FROM avtopark 
INNER JOIN dogovory ON avtopark.ID_Avto = dogovory.ID_Avto 
WHERE dogovory.Identify = 'Не действительный';";

        public string Select_Identify_Avto = $@"SELECT avtopark.Identify FROM avtopark WHERE avtopark.ID_Avto = @ID;";

        public string Select_Comments_Act = $@"SELECT acts.Comments FROM acts WHERE acts.ID_Act = @ID;";

        public string Select_Prava_Clienty = $@"SELECT CONCAT(prava.AM,';',prava.A1,';',prava.A,';',prava.B,';',prava.C,';',prava.D) 
FROM prava 
INNER JOIN clienty ON prava.ID_Clienta = clienty.ID_Clienta
WHERE clienty.ID_Clienta = @ID;";

        public string Select_Kat_Avto = $@"SELECT if(avtopark.Categoria_Avto = 'AM', 0,
if(avtopark.Categoria_Avto = 'A1', 1,
if(avtopark.Categoria_Avto = 'A', 2,
if(avtopark.Categoria_Avto = 'B', 3,
if(avtopark.Categoria_Avto = 'C', 4,
if(avtopark.Categoria_Avto = 'D', 5, 6)))))) 
FROM avtopark WHERE avtopark.ID_Avto = @ID;";

        public string Select_Print_Dogovory = $@"SET lc_time_names = 'ru_RU';
SELECT CONCAT(CONCAT('№ ',dogovory.ID_Dogovora,' от ',DATE_FORMAT(dogovory.Date,'%d %M %Y')),';',
CONCAT(sotrudniki.Familiya, ' ', sotrudniki.Imya, ' ', sotrudniki.Otchestvo),';',
CONCAT(clienty.Familiya, ' ', clienty.Imya, ' ', clienty.Otchestvo),';',
CONCAT(avtopark.Marka, ' ', avtopark.Model),';',
avtopark.Gos_Znak,';', avtopark.VIN_Nomer,';', avtopark.Stoimost,';', DATE_FORMAT(dogovory.N_Arendy,'%d %M %Y'),';', DATE_FORMAT(dogovory.K_Arendy,'%d %M %Y'),';', dogovory.Summa,';',
clienty.Nom_Pass,';',clienty.Ident_Nom,';',clienty.Telephone,';',clienty.Email,';',DATE_FORMAT(dogovory.Date,'%d %M %Y'))
FROM dogovory INNER JOIN clienty ON dogovory.ID_Clienta = clienty.ID_Clienta
INNER JOIN sotrudniki ON dogovory.ID_Sotrudnika = sotrudniki.ID_Sotrudnika
INNER JOIN avtopark ON dogovory.ID_Avto = avtopark.ID_Avto
WHERE dogovory.ID_Dogovora = @ID;";

        public string Select_Print_Acts = $@"SET lc_time_names = 'ru_RU';
SELECT CONCAT(CONCAT(acts.Name,' №',acts.ID_Act,' от ', DATE_FORMAT(acts.Date, '%d %M %Y')),';', 
CONCAT('№ ',dogovory.ID_Dogovora,' от ',DATE_FORMAT(dogovory.Date,'%d %M %Y')),';',
CONCAT(sotrudniki.Familiya, ' ', sotrudniki.Imya, ' ', sotrudniki.Otchestvo),';',
CONCAT(avtopark.Marka, ' ', avtopark.Model,' Гос. знак: ',
avtopark.Gos_Znak,', VIN-номер: ', avtopark.VIN_Nomer),';',
CONCAT(clienty.Familiya, ' ', clienty.Imya, ' ', clienty.Otchestvo),';',
acts.Comments)
FROM acts INNER JOIN dogovory ON acts.ID_Dogovora = dogovory.ID_Dogovora
INNER JOIN avtopark ON dogovory.ID_Avto = avtopark.ID_Avto
INNER JOIN sotrudniki ON dogovory.ID_Sotrudnika = sotrudniki.ID_Sotrudnika
INNER JOIN clienty ON dogovory.ID_Clienta = clienty.ID_Clienta
WHERE acts.ID_Act = '3';";

        public string Select_Dogovor = $@"SET lc_time_names = 'ru_RU';
SELECT CONCAT('№ ',dogovory.ID_Dogovora,' от ',DATE_FORMAT(dogovory.Date, '%d %M %Y')) FROM dogovory WHERE dogovory.ID_Dogovora = @ID;";
        //Select

        //Insert
        public string Insert_Doljnosti = $@"INSERT INTO doljnosti (Name) VALUES (@Value1);";

        public string Insert_Price = $@"INSERT INTO price (Name, Stoimost, Skidka) VALUES (@Value1, @Value2, @Value3);";

        public string Insert_Avtopark = $@"INSERT INTO avtopark (Marka, Model, Categoria_Avto, ID_Price, Gos_Znak, VIN_Nomer, Stoimost) VALUES(@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7);";

        public string Insert_Sotrudniki = $@"INSERT INTO sotrudniki (Familiya, Imya, Otchestvo, ID_Doljnosti, Telephone) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5);";

        public string Insert_Clienty = $@"INSERT INTO clienty (Familiya, Imya, Otchestvo, Telephone, Email, Nom_Pass, Ident_Nom) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7);";

        public string Insert_Prava = $@"INSERT INTO prava (ID_Clienta, Nom_VodPrav, AM, A1, A, B, C, D) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7, @Value8);";

        public string Insert_Dogovory = $@"INSERT INTO dogovory (ID_Sotrudnika, ID_Clienta, N_Arendy, K_Arendy, Summa, ID_Avto, Date) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7);";

        public string Insert_Acts = $@"INSERT INTO acts (Name, Date, ID_Dogovora, ID_Sotrudnika, ID_Avto, Comments) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6);";
        //Insert

        //Update
        public string Update_Doljnosti = $@"UPDATE doljnosti SET Name = @Value1 WHERE ID_Doljnosti = @ID;";

        public string Update_Price = $@"UPDATE price SET Name = @Value1, Stoimost = @Value2, Skidka = @Value3 WHERE ID_Price = @ID;";

        public string Update_Avtopark = $@"UPDATE avtopark SET Marka = @Value1, Model = @Value2, Categoria_Avto= @Value3, ID_Price = @Value4, Gos_Znak = @Value5, VIN_Nomer = @Value6, Stoimost = @Value7 WHERE ID_Avto = @ID;";

        public string Update_Sotrudniki = $@"UPDATE sotrudniki SET Familiya = @Value1, Imya = @Value2, Otchestvo = @Value3, ID_Doljnosti = @Value4, Telephone = @Value5 WHERE ID_Sotrudnika = @ID;";

        public string Update_Clienty = $@"UPDATE clienty SET Familiya = @Value1, Imya= @Value2, Otchestvo = @Value3, Telephone = @Value4, Email = @Value5, Nom_Pass = @Value6, Ident_Nom= @Value7 WHERE ID_Clienta = @ID;";

        public string Update_Prava = $@"UPDATE prava SET ID_Clienta = @Value1, Nom_VodPrav = @Value2, AM = @Value3, A1 = @Value4, A = @Value5, B= @Value6, C = @Value7, D = @Value8 WHERE ID_Prav = @ID;";

        public string Update_Dogovory = $@"UPDATE dogovory SET ID_Sotrudnika = @Value1, ID_Clienta = @Value2, N_Arendy = @Value3, K_Arendy = @Value4, Summa = @Value5, ID_Avto = @Value6 WHERE ID_Dogovora = @ID;";

        public string Update_Acts = $@"UPDATE acts SET Name = @Value1, ID_Dogovora = @Value2, ID_Sotrudnika = @Value3, ID_Avto = @Value4, Comments = @Value5 WHERE ID_Act = @ID;";

        public string Update_Identify_Dogovory = $@"UPDATE dogovory SET dogovory.Identify = 'Не действительный'
WHERE dogovory.ID_Dogovora = @ID;";

        public string Update_K_Date_Dogovory = $@"UPDATE dogovory SET dogovory.K_Arendy = DATE_ADD(CURDATE(), INTERVAL 1 DAY),
dogovory.Summa = dogovory.Summa + (SELECT price.Stoimost-price.Skidka/100 FROM price INNER JOIN avtopark ON avtopark.ID_Price = price.ID_Price 
WHERE avtopark.ID_Avto = (SELECT dogovory.ID_Avto FROM dogovory WHERE dogovory.ID_Dogovora = @ID)) * 
(SELECT DATEDIFF(DATE_ADD(CURDATE(), INTERVAL 1 DAY), dogovory.K_Arendy) FROM dogovory WHERE dogovory.ID_Dogovora = @ID)
WHERE dogovory.K_Arendy < CURDATE() AND dogovory.ID_Dogovora = @ID;";

        public string Update_Identyfy_Avtopark = $@"UPDATE avtopark SET avtopark.Identify = 'Свободна' 
WHERE avtopark.ID_Avto = (SELECT dogovory.ID_Avto FROM dogovory WHERE dogovory.ID_Dogovora = @ID);";

        public string Update_Identify_Avtopark1 = $@"UPDATE avtopark SET avtopark.Identify = 'Занята' WHERE avtopark.ID_Avto = @ID;";
        //Update

        //Delete
        public string Delete_Doljnosti = $@"DELETE FROM doljnosti WHERE ID_Doljnosti = @ID;";

        public string Delete_Price = $@"DELETE FROM price WHERE ID_Price = @ID;";

        public string Delete_Avtopark = $@"DELETE FROM avtopark WHERE ID_Avto = @ID;";

        public string Delete_Sotrudniki = $@"DELETE FROM sotrudniki WHERE ID_Sotrudnika = @ID;";

        public string Delete_Clienty = $@"DELETE FROM clienty WHERE ID_Clienta = @ID;";

        public string Delete_Prava = $@"DELETE FROM prava WHERE ID_Prav = @ID;";

        public string Delete_Dogovory = $@"DELETE FROM dogovory WHERE ID_Dogovora = @ID;";

        public string Delete_Acts = $@"DELETE FROM acts WHERE ID_Act = @ID;";
        //Delete
    }
}