# Machine learning Jumper
## Groep 1
|Naam|Nr|
|-|-|
|Wouter Van Nueten|107229|
|Maxim Janssens|107104|

## Introductie
Het doel van deze repo is illustreren hoe een simpele ml-agent binnenin unity werkt.

We doen dit aan de hand van een simpel spel. Het spel verloopt als volgt: er is een agent (die we moeten trainen) en een obstakel (die slechts 1 ding kan: recht vooruit gaan en botsen tegen alles wat op zijn weg komt).

In de volgende illustratie zien we de agent in het groen aangeduid, en het obstakel in het rood. Het spel speelt zich af in een 3D-wereld waarin de agent de mogelijkheid heeft om te springen. De agent zal moeten leren om over het obstakel te springen wanneer het op hem afkomt.

![](Illustrations/Tekening1-01.svg)

Om ervoor te zorgen dat de agent weet wat hij moet doen, zorgen we dat hij een reward krijgt voor op de grond te staan, en tegelijk ook wordt gestraft als het obstakel hem kan raken.

Als extraatje zal het voor de agent ook mogelijk zijn om bonuspunten te krijgen door `munten` te vangen die op willekeurige plaatsen in het speelveld verschijnen.

## Set-up
