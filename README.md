# GalaxyTest
[Ccылка на сайт](https://galaxytest20200601180228.azurewebsites.net/)


(*Кнопка GalaxyTest в футере = возврат на главную страницу*)

### Стек технологий
* Аутентификация: Identity + JWT Bearer.
* База данных: MSSQL
* ORM: Entity Framework Core
* Client: Angular 8.2.12


В базе данных хранятся хэши паролей.

### Данные для входа

Аккаунты различаются информацией о пользователе.

Логин | Пароль
--- | ---
vasilev | Qwerty1!
galaxy | Pa$$w0rd
admin | Admin*0

### База данных 
Identity автоматически генерирует таблицу пользователей в базе данных.
Информация о пользователях хранится в этой же таблице (т.к. связь "один-к-одному"), используется атрибут [Owned].
