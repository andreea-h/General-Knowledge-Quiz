# General-Knowledge-Quiz
Aplicatie cu interfata grafica care simuleaza un generator de teste grila, de cultura generala, cu intrebari extrase in mod aleator dintr-un set predefinit

Intrebarile aferente textului sunt alese in mod aleator din fisierul "test.txt".
Aplicatia prezinta o fereastra de start cu start in care utilizatorul poate introduce numarul de intrebari pe care doreste sa le contina testul
(in cazul in care este introdus un sir invalid la intrare, utilizatorul este atentionat printr-un MessageBox).

La apasarea butonului "Incepe testul", se vor afisa intrebarile rand pe rand, trecerea la urmatoarea intrebare fiind conditionata de alegerea unui raspuns la intrebare curenta; progresul jucatorului este urmarit printr-un ProgressBar care evidentiaza cate intrebari din numarul introdus initial au fost parcurse pana la momentul actual. Validarea corectitudinii raspunsului ales se face in momentul in care user-ul trece la urmatoarea intrebare, prin intermediul unui semnal sonor care sa indice daca raspunsul a fost gresit sau corect. De asemenea, pe toata durata jocului (din momentul apasarii butonului "Incepe testul") ruleaza muzica care sa destinda jucatorul: Mozart - Simfonia nr. 40 in G minor :).

La finalul jocului este afisat punctajul obtinut (fiecare raspuns corect valoreaza 1p, puncrtajul este obtinut numarand intrebarile la care s-a raspuns corect).

![alt-text](https://github.com/andreea-h/General-Knowledge-Quiz/blob/master/fereastra_start.png)
![alt-text](https://github.com/andreea-h/General-Knowledge-Quiz/blob/master/fereastra_test.png)
![alt-text](https://github.com/andreea-h/General-Knowledge-Quiz/blob/master/final_joc.png)
![alt-text](https://github.com/andreea-h/General-Knowledge-Quiz/blob/master/final_joc_2.png)
