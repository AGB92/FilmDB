# FilmDB
## Baza filmów FilmDB


Stwórz nowy projekt, który będziemy rozwijać.
To będzie baza filmowa. Możemy nazwać go FilmDB.


### Zadanie 1
1. Załóż nowy projekt w serwisie GitHub.
2. Przy tworzeniu nowego projektu dodaj plik .gitignore dls Visual Studio.
3. Stwórz nowy projekt .NET Core MVC FilmDB.
4.Stwórz nową bazę danych FilmDB. Jeśli to konieczne zainstaluj wcześniej SQL Express.
5. Zainstaluj pakiety umożliwiające korzystanie z Entity Framework Core.
    
### Zadanie 2
1. Dodaj model FilmModel.
2. W modelu utwórz właściwości: ID typu int - klucz główny. Title typu string - tytuł filmu - właściwość musi być wymagana. Year typu int - tekst filmu.
3. Dodaj nowy kontroler FilmController.
4. Ustaw powyższy kontroler jako domyślny w pliku Program.cs.

### Zadanie 3
1. Utwórz klasę kontekstu o nazwie FilmContext, która dziedziczy po klasie DbContext.
2. W kontekście utwórz właściwość DbSet<FilmModel> o nazwie Films.
3. Pobierz lub utwórz łańcuch połączenia do bazy FilmDb.
4. Ustaw łańcuch połączenia w metodzie OnConfiguring, aby korzystał z bazy Microsoft Sql Sever.

### Zadanie 4
1. Utwórz migrację o nazwie Initial.
2. Zobacz pliki migracji.
3. Przy pomocy Package Manager Console zaktualizuj bazę danych na podstawie migracji.
4. Zobacz tabelę utworzoną w bazie danych.

### Zadanie 5
1. Utwórz w projekcie klasę:
```
    public class FilmManager
    {
        public FilmManager AddFilm(FilmModel filmModel)
            {return this;}

        public FilmManager RemoveFilm(int id)
            {return this;}

        public FilmManager UpdateFilm(FilmModel filmModel)
            {return this;}

        public FilmManager ChangeTitle(int id, string newTitle)
            {return this;}

        public FilmManager GetFilm(int id)
            {return null;}

        public List<FilmModel> GetFilms()
            {return null;}
    }
```

2. W klasie FilmManager w metodzie AddFilm należy:
   - Utworzyć obiekt kontekstu o nazwie context w deklaracji using.
   - Dodać do kontekstu obiekt typu FilmModel przekazany w parametrze metody AddFilm.
Obiekt dodajemy wywołując metodę Add na właściwości Films kontekstu.
Zatwierdzić zmiany wywołując metodę SaveChanges na obiekcie kontekstu.
3. W akcji Index kontrolera Film utwórz obiekt klasy FilmModel o nazwie FilmModel przypisując do właściwości dowolne dane.
4. Do właściwości ID modelu przypisz wartość 1.
5. Utwórz obiekt klasy FilmManager o nazwie FilmManager i sprawdź działanie metody AddFilm jako argument przekazując obiekt FilmModel.
6. Zobaczy typ i komunikat rzuconego wyjątku.

### Zadanie 6
1. Zmień implementację metody AddFilm w następujący sposób:
   - Złap wyjątki rzucane w momencie wywoływania metody SaveChanges.
   - Gdy złapany zostanie typ wyjątku spowodowany uzupełnieniem właściwości ID, do właściwości ID przypisz 0 i ponów zapis do bazy wywołując metodę SaveChanges.

### Zadanie 7
1. W klasie FilmManager w metodzie RemoveFilm należy:
   - Utworzyć obiekt kontekstu o nazwie context w deklaracji using.
   - Pobrać obiekt typu FilmModel za pomocą metody Single lub SingleOrDefault. Obiekt pobierz na podstawie właściwości ID modelu i parametru metody.
   - Usunąć pobrany model z bazy przy pomocy metody Remove, która powinna być wywołana na właściwość Films kontekstu.
   - Zatwierdzić zmiany metodą SaveChanges.

### Zadanie 8
1. W klasie FilmManager zmień implementację metody GetFilm w następujący sposób:
   - Utworzyć obiekt kontekstu o nazwie context w deklaracji using.
   - Pobrać obiekt typu FilmModel za pomocą metody SingleOrDefault. Obiekt pobierz na podstawie właściwości ID modelu i parametru metody.

### Zadanie 9
1. W klasie FilmManager w metodzie ChangeTitle należy:
   - Utworzyć obiekt kontekstu o nazwie context w deklaracji using.
   - Pobrać obiekt typu FilmModel za pomocą metody Single. Obiekt pobierz na podstawie właściwości ID modelu i parametru metody.
   - Zmodyfikować właściwość Title, na wartość title z parametru.
   - Zatwierdź zmiany metodą SaveChanges.

### Zadanie 10
1. Sprawdź działanie metody ChangeTitle z argumentem null przekazanym w miejsce parametru newTitle.
2. Zobacz rzucony wyjątek.
3. Zmień implementację metody w następujący sposób:
   - Jeśli właściwość Title parametru równa się null przypisz do właściwości tekst Brak Tytułu.

### Zadanie 11
1. W klasie FilmManager w metodzie UpdateFilm należy:
   - Utwórz obiekt kontekstu o nazwie context w deklaracji using.
   - Zaktualizować obiekt przekazany w parametrze metody, używając metody Update właściwości Films kontekstu.
   - Zatwierdź zmiany metodą SaveChanges.

### Zadanie 12
1. W klasie FilmManager zmień implementację metody GetFilms w następujący sposób:
   - Utworzyć obiekt kontekstu o nazwie context w deklaracji using.
   - Pobrać listę obiektów typu FilmModel za pomocą metody ToList.

### Zadanie 13
1. W kontrolerze Film utwórz akcję Add, wywoływaną tylko na żądanie get.
2. Akcja powinna wyświetlać formularz typu FilmModel, kierowany na akcję Add, zbudowany na podstawie modelu FilmModel.
3. W kontrolerze Home utwórz akcję Addz parametrem typu FilmModel, wywoływaną tylko na żądanie post.

### Zadanie 14
1. W akcji Index pobierz wszystkie filmy z tabeli Films.
2. filmy przekaż do widoku przez model.
3. W widoku wyświetl listę filmów w tabeli <table>.
4. Nad tabelą utwórz link kierujący na akcję Add, która pozwoli dodać nowy film.

### Zadanie 15
1. W kontrolerze Film utwórz akcję o nazwie Remove typu get, która przyjmie parametr typu int o nazwie id, którym będzie klucz główny filmu do usunięcia.
   - Akcja powinna pobrać film o podanym id i przekazać go do widoku przez model.
   - Dla akcji Remove utwórz widok i wyświetl wszystkie informacje o filmie oraz przycisk z tekstem Potwierdź Usunięcie, kierujący na akcję RemoveConfirm typu post.
   - W widoku wyświetl również przycisk pozwalający wrócić do akcji Index.
2. W kontrolerze utwórz akcję typu post o nazwie RemoveConfirm, która przyjmuje parametr typu int o nazwie id.
   - Akcja powinna usuwać encję o podanym id z bazy danych.
   - Przed usunięciem sprawdź czy film o podanym id istnieje w bazie.
   - Po usunięciu filmu akcja powinna przekierować na akcję Index.
3. W widoku Index przy każdym filmie w tabeli utwórz przycisk kierujący na akcję Remove z id danego filmu.

### Zadanie 16
1. W kontrolerze Film utwórz dwie akcje o nazwie Edit:
2. Akcja typu get z parametrem id typu int powinna pobrać film o podanym identyfikatorze i przekazać go do widoku przez model.
3. Utwórz widok dla akcji Edit, który wyświetli formularz edycji. Formularz w przeciwieństwie do formularza dodawania powinien również zawierać ukryte pole ID.
4. Formularz powinien być typu post i kierować na akcję Edit.
5. Akcja typu post z parametrem typu FilmModel o nazwie filmModel.