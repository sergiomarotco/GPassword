Название доклада: Аутентификация методом динамического графического пароля. НГТУ.
Руководитель: д.т.н, профессор Абденов Амирза Жакенович

# ТЕЗИСЫ
<b>Графический пароль</b> – метод разблокировки мобильных устройств путем выполнения определенных операций над сенсорным экраном, результатом которых является получение доступа к устройству. Речь пойдет именно о таких устройствах, т.к. в обычных персональных компьютерах обычно отсутствуют сенсорные экраны, а для аутентификации в программах чаще используется пара логин - пароль. 
<br>Допустим, в настройках мобильного устройства мы указали метод разблокировки – графический пароль. Это значит, что мы придумываем пароль, например «A?BC❀» - <b>секретный пароль (постоянный)</b>. Введем понятие <b>динамического пароля</b> – пароль, который генерируется на основе постоянного. 
<br><b>Динамический графический пароль</b> - Аутентификация пользователя на устройстве без отображения постоянного пароля, в каком – либо виде, так чтобы, например, посторонний человек не смог понять, что за пароль был введен, даже запомнив все действия которые легальный пользователь выполнил при вводе пароля, и даже запомнив динамический пароль. Один из методов динамического пароля хорошо описан в статье «Динамический пароль», в данном случае речь пойдет именно о динамическом графическом пароле.
Исходя из выше сказанного, динамический графический пароль устраняет самый важный недостаток обычных графических паролей: ввод графического пароля компрометирует сам пароль, и для злоумышленника завладевшего вашим устройством не составит труда подобрать пароль.

# Суть разработанного метода
<br>При нажатии кнопки включения экрана устройства, псевдослучайным образом генерируется сетка, состоящая в простейшем случае из букв простого алфавита, рассмотрим пример пароля - «A?BC❀». Таким образом, в усложненном варианте это может быть сетка с символами, картинками, смайликами, цветные элементы, что угодно. Эта сетка выводится на экран устройства. Пример сетки представлен на рисунке 1. Среди символов в этой сетке обязательно присутствуют символы нашего постоянного пароля.
<img src='https://github.com/sergiomarotco/GPassword/blob/master/%D0%A0%D0%B8%D1%81%D1%83%D0%BD%D0%BA%D0%B8/%D0%A0%D0%B8%D1%81%D1%83%D0%BD%D0%BE%D0%BA6.jpg'/>
<br>Рис. 1. Экран приветствия устройства.

<br>Для разблокировки устройства в поле «Динамический пароль» необходимо ввести динамический пароль.

# Метод определения динамического пароля путем мысленных вычислений
1.	Необходимо найти буквы нашего пароля на сетке;
2.	Мысленно соединить эти буквы линией (рисунок 2), двигаясь вверх, вниз, влево или вправо;
3.	Посчитать количество пройденных клеток, последовательно пройдя по всем буквам пароля – в приведенном примере динамический пароль должен получиться равным цифре 36. Другими словами: необходимо вычислить расстояние в клетках между буквами постоянного пароля, выведенными среди других букв в сетке, полученное расстояние будет являться значением динамического пароля;
4.	Ввести значение динамического пароля в поле «Динамический пароль»;
5.	Нажать кнопку «ОК» – подтвердив тем самым ввод динамического пароля.
<img src='https://github.com/sergiomarotco/GPassword/blob/master/%D0%A0%D0%B8%D1%81%D1%83%D0%BD%D0%BA%D0%B8/%D0%A0%D0%B8%D1%81%D1%83%D0%BD%D0%BE%D0%BA6.jpg'/>
Рис. 2. Случай мысленного подсчета цифр и ввод динамического пароля.

# Метод определения динамического пароля путем его отображения на экране (менее безопасно)
1.	Нам необходимо найти буквы нашего пароля на сетке;
2.	Провести по ним пальцем, устройство само выделяет помеченные пальцем клетки и само вводит цифру 36 в поле «Динамический пароль». На рисунке 3, приведены 2 из возможных правильных способов выделения клеток;
3.	Нажать кнопку «ОК» – подтвердив тем самым ввод динамического пароля;
4.	В случае верно введенного динамического пароля, устройство будет разблокировано.
<img src='https://github.com/sergiomarotco/GPassword/blob/master/%D0%A0%D0%B8%D1%81%D1%83%D0%BD%D0%BA%D0%B8/%D0%A0%D0%B8%D1%81%D1%83%D0%BD%D0%BE%D0%BA12.jpg'/>
<br>или
<br><img src='https://github.com/sergiomarotco/GPassword/blob/master/%D0%A0%D0%B8%D1%81%D1%83%D0%BD%D0%BA%D0%B8/%D0%A0%D0%B8%D1%81%D1%83%D0%BD%D0%BE%D0%BA13.jpg'/>
<br>Рис. 3. Случай ввода с отображением пароля.

<br>Проверка введенной цифры (действия на стороне устройства):
1.	Программа (операционная система мобильного устройства) генерирует сетку и выводит на экран;
2.	Дожидается подтверждения пользователем введенного им динамического пароля;
3.	Считывает из памяти пароль, разбивает на буквы;
4.	Находит буквы на сетке;
5.	Сама высчитывает расстояния в клетках между буквами алфавита;
6.	Сверяет вычисленное число с введенным пользователем;
7.	Разблокирует устройство в случае правильного ввода, блокирует устройство и/или возвращается к п.1.

# Пример ошибочного ввода
На рисунке 4 представлены 2 примера ошибочного ввода.
<img src='https://github.com/sergiomarotco/GPassword/blob/master/%D0%A0%D0%B8%D1%81%D1%83%D0%BD%D0%BA%D0%B8/%D0%A0%D0%B8%D1%81%D1%83%D0%BD%D0%BE%D0%BA14.jpg'/>
<br>или
<br><img src='https://github.com/sergiomarotco/GPassword/blob/master/%D0%A0%D0%B8%D1%81%D1%83%D0%BD%D0%BA%D0%B8/%D0%A0%D0%B8%D1%81%D1%83%D0%BD%D0%BE%D0%BA15.jpg'/>
<br>Рис. 4. Пример ошибочного ввода.

В попытке подбора или при ошибочном вводе, человек в данном случае вводит цифру 40,а нужно ввести 36.
Возможные модификации:
1.	Длинный пароль, соответственно некоторые буквы могут засчитываться дважды – так как в приведенном примере;
2.	Изменение размера сетки, например 20 х 20;
3.	Трехкратное повторение ввода, для уменьшения вероятности подбора;
4.	Трехкратное повторение ввода, но каждый раз разных паролей (три пароля или три части одного пароля);
5.	Использование различных символов, картинок, цветов, разноцветных картинок вместо обычных символов алфавита;
6.	Использование данного метода в качестве двухфакторной аутентификации (PIN + динамический графический пароль).

# Пример для самопроверки
Укажите динамический пароль для постоянного пароля «A?BC❀»
<br><img src='https://github.com/sergiomarotco/GPassword/blob/master/%D0%A0%D0%B8%D1%81%D1%83%D0%BD%D0%BA%D0%B8/111.jpg?raw=true' />
<br>Рис. 5. Пример для самопроверки.

<br>Правильный ответ: 43.

# Выводы
Данный метод динамического графического пароля может использоваться для прохождения аутентификации на доступ к устройству, приложению в условиях, когда есть риск, что ввод пароля может быть обнаружен, а сам пароль скомпрометирован. Рассмотрим плюсы и минусы такого способа:

## Плюсы
1.	При мысленном определении динамического пароля, постоянный пароль не отображается, такие методы в принципе очень эффективны;
2.	Нельзя определить пароль по следам от пальцев на экране устройства, каждый раз сетка генерируется случайным образом;
3.	Для сторонников двухфакторной аутентификации, например, по SMS, этим способом можно пройти аутентификацию даже быстрее.

## Минусы
1.	При достаточно маленьком поле, коротком пароле, вероятность угадывания пароля высока;
2.	Огромное же поле вызывает трудности с нахождением символов постоянного пароля;
3.	Значение динамического пароля имеет невысокую границу сверху, например, не больше 60, для короткого пароля.
