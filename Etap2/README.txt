Program do obliczenia przybliżonej wartości całki n-tego wielomianu Czebyszewa ze wzoru trapezów.
Program wylicza wartość początkowo metodą sekwencyjną, a następnie metodą działającą w klastrze opartym na zdalnych wywołaniach za pomocą platformy gRPC.


Instrukcja:
1) Wartości dla następujących parametrów nalezy wprowadzić do pliku dane.txt w folderze Etap2:
- n - stopień wielomian Czebyszewa
- a - początek przedziału całki 
- b - koniecz przedziału całki
- N - ilość podprzedziałów całki

2) W pliku start_workers.sh ustawić porty, na których mają zostać uruchomione serwery do gRPC
(Ilość portów = ilość programów równolegle wykonujących obliczenia)
(Domyślnie ustawiono 8 portów)

3) W pliku run.sh również należy podać porty do serwerów, na których mają zostać wykonane obliczenia
(Domyślnie ustawiono 8 portów)

4) Uruchumić z poziomu konsoli serwery: bash start_workers.sh

5) Uruchomić z poziomu konsoli aplikację: bash run.sh


Wykonali:
Aleksander Kotecki
Andrzej Daniel
