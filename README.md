# asp.netcore

Volt sulis beadandó feladat.

A feladat lényege volt egy asp.net api endpoint létrehozása, és annak valamilyen feldolgozása, az órán bemutatott angular szerint.

A webszerver az Instantgram_API-t kiválasztva a szerver a :7766 os porton indul el és kéri a https protokol használatát.
Az Angular klienst csak azért hagyom benne a projektben, hogy demostrálni lehessen, hogy elindul és működik, bár idő hiányában kimaradt a livereload, mert 3 óra alatt lett összepárosítva leadás előtt.


# Első indításn:
Mivel egy ideje nem nyúltam hozzá nekem feldobta a https certificate errort ezt projet mappájában (.sln mellett) a következő két parancs Powershellben megoldotta:
 * dotnet dev-certs https --clean
 * dotnet dev-certs https -t
Ezután újra kellet indítani a VS-t

Package Manager Consoleban 'update-database'-t kell futtani és el is indul rendesen.
  2 kezdeti felhasználó lett létrehozva:
    admin: adminpass
    ferenc: ferencpass

Angular mappájában npm install után egyből lehet futtatni.

# Bemutatás
Az angular servert alkalmazást elindítva egy üres oldalra dob minket itt Jobb Felső sarokban a Loginra kattintva egyik felhasználóba beléphetünk.
![image](https://user-images.githubusercontent.com/66252236/140044374-21e16bc3-3b70-4430-b70b-7c40aa07c9c8.png)

Választhatunk kép és videó megosztás mellett és a Create Post megnyomásával fel is töltődik a képünk URL-je.
![image](https://user-images.githubusercontent.com/66252236/140044625-8d887489-bc70-49b3-8d79-636a7f666c33.png)

Az autómatikus frissítés nem működik, de az oldalt frissítve láthatjuk, hogy megjeleni a posztunk, amelyet minden felhasználó lát és hozzá tud szólni.
![image](https://user-images.githubusercontent.com/66252236/140044704-b4df2d63-33ce-4c3a-bfa3-35e2c6f04329.png)



