# Simulation

Simulation für unser Projektpraktikum

Diese Simulation simuliert unsere Architektur für eine Katastrophenkommunikation.

Realisiert wird dies mit Unity.

## Inhaltsverzeichnis
- [Unity](#unity)
  - [Projekt importieren in Unity](#projekt-importieren-in-unity)
  - [Inhalt und Starten der Simulationen](#inhalt-und-starten-der-simulationen)
  - [Kurzübersicht Bedienung Unity](#kurzübersicht-bedienung-unity)
    - [Projektverzeichnis](#projektverzeichnis)
    - [Hierarchy](#hierarchy)
    - [Inspector](#inspector)
    - [Simulation starten](#simulation-starten)
    - [Bedienung der Kamera](#bedienung-der-kamera)
    - [Erstellen von Nachrichten](#erstellen-von-nachrichten)
- [Projektübersicht](#projektübersicht)
  - [Szenen](#szenen)
  - [Nachrichtentypen](#nachrichtentypen)
  - [Nodetypen](#nodetypen)
  - [Wegpunkte](#wegpunkte)
- [Referenzen](#referenzen)
- [Disclaimer](#disclaimer)

## Unity

Benötigt wird Version 2020.3.7f1

Am einfachsten Installiert über [Unity Hub](https://unity.com/download) mit Download der Version aus dem [Archiv](https://unity3d.com/get-unity/download/archive) <br>
Getestet wurde es mit Windows und Fedora (Download Unity Hub über [Flathub](https://flathub.org/apps/details/com.unity.UnityHub))

### Projekt importieren in Unity

Der Ordner [Simulation](/Simulation) ist ein Unity Projekt und kann als solches einfach in Unity Hub importiert werden. <br>
Von dort kann es dann auch mit einfachem Klick gestartet werden.

### Inhalt und Starten der Simulationen

TODO (?) or delete?

### Kurzübersicht Bedienung Unity

#### Projektverzeichnis

Wenn Unity gestartet ist, so kann man unten Rechts und unten Mitte den Projektinhalt sehen.
![grafik](https://user-images.githubusercontent.com/77550792/203961108-56b0486d-4da9-48c0-a593-fba13c2bb564.png)

#### Hierarchy

Die Hierarchie ist auf der linken Seite. In ihr können die aktiven Elemente angeklickt und dann mit Hilfe des [Inspectors](#inspector) manipuliert werden.
![grafik](https://user-images.githubusercontent.com/77550792/204004133-26320d7e-8e7c-467e-ac2b-fa32533f43de.png)

#### Inspector

Der Inspector ist auf der rechten Seite und in ihm können die Eigenschaften von Elementen gesehen und verändert werden. <br>
![grafik](https://user-images.githubusercontent.com/77550792/204005178-814a01ea-0375-44dc-9420-507a64f243b3.png) <br>
Besonders wichtig ist da das [Create Message Script](/Simulation/Assets/Scripts/MessageDot/createMessageScript.cs) auf Funktürmen und THW Nodes, wo der Inhalt von neu zu erstellenden Nachrichten eingetragen wird. <br>
![grafik](https://user-images.githubusercontent.com/77550792/204005076-444dbf61-086a-433c-8ef5-76645faa587a.png)

#### Simulation starten

Nach der Auswahl einer [Szene](#szenen) kann diese Szene einfach durch Klicken auf den Play Button oben in der Mitte gestartet werden. <br>
Genauso kann sie auch Pausiert oder Beendet werden

#### Bedienung der Kamera

Die Kamera kann während der Simulation bewegt werden. Zum Rein- und Rauszoomen wird das Mausrad benutzt. Zur Bewegung nach Oben, Unten, Links und Rechts werden die Pfeiltasten benutzt. <br>

Mit Linksklick können Nodes angewählt werden. Dann erscheint Links im Bild eine Übersicht mit allen Nachrichten, die diese Node kennt. Angezeigt werden dessen Namen (Feld: `Content`) und das Risiko Niveau (Feld: `Risk Lvl`) <br>
![grafik](https://user-images.githubusercontent.com/77550792/204010565-ce781082-3ea3-4177-b833-167d6c248f39.png) <br>
Auf diese Nachrichten kann man wieder draufklicken um den genauen Inhalt zu sehen. <br>
![grafik](https://user-images.githubusercontent.com/77550792/204008882-2b48348a-7b85-4d21-b972-14494995780f.png) <br>
Abwählen kann man die Nachrichten und Nodes dann wieder mit einem Rechtsklick.

#### Erstellen von Nachrichten
Nachrichten werden von Funktürmen und THW Nodes mit Hilfe des Skripts [Create Message Script](/Simulation/Assets/Scripts/MessageDot/createMessageScript.cs) im [Inspector](#inspector) erstellt. In unseren Szenarios sind dort immer schon sinnvolle Werte eingetragen, dem Szenario entsprechend. <br>
Versendet werden können diese Nachrichten für alle Nodes mit diesem Skript gleichzeitig durch drücken der Leertaste. <br>
Will man allerdings nur mit einzelnen Nodes eine Nachricht versenden, so muss man bei den anderen berechtigten Nodes das Skript deaktivieren. <br>

Die Spamnode erstellt intern automatisch Nachrichten. Zur Abstraktion zu den normalen Nachrichten, haben Spamnachhrichten als Bedrohung den Grund "Alienangriff" und das Bedrohungslevel 9001. <br>
Die Spamnode sendet jedes Mal die gleiche Nachricht, aber jeweils mit einer anderen, random ID, weshalb diese Nachrichten trotzdem von anderen Nodes als eine andere, neue Nachricht erkannt werden. <br>
Gestartet und Gestoppt werden kann die Aktivität der Spam Node durch drücken der Taste P.

## Projektübersicht

Im [Projektverzeichnis](#Projektverzeichnis) sind folgende Ordner wichtig:
- [Assets/Scenes](/Simulation/Assets/Scenes): Hier liegen unsere Szenen drin, welche aus Szenarios und Test/Debug Szenen bestehen.
- [Assets/Scripts/MessageDot](/Simulation/Assets/Scripts/MessageDot): Hier befinden sich die Scripte und Prefabs für die Nachrichten drin.
- [Assets/Scripts/Node](/Simulation/Assets/Scripts/Node): Hier befinden sich die Scripte und Prefabs für die Nodes drin.
- [Assets/Scripts/Waypoint](/Simulation/Assets/Scripts/Waypoint): Hier befinden sich die Scripte und Prefabs für die Wegpunkte drin. Diese können sowohl bei Nodes zur Wegffindung genutzt werden, als auch in Nachrichten als Gefahrenquellen.

### Szenen

Unsere Simulation hat verschiede Szenen, für verschiedene Zwecke:
- Debug: Testszene für die Bewegung einer Nodes über verschiedene Wegpunkte. <br>
![grafik](https://user-images.githubusercontent.com/77550792/203973256-9e9add2a-6d9e-46b7-a92f-930b3b6e62c0.png)
- NodeTypesDemo: Demonstration und Testen der unterschiedlichen Nodetypen. Besonders der Spam Node und der Blockierung von Spam. Aber auch, dass Wifi und Bluetooth Nodes nicht miteinander kommunizieren können. <br>
![grafik](https://user-images.githubusercontent.com/77550792/203973602-309cd4a0-f45b-401d-81e9-20ab09783b77.png)
- TestHealthbar: Demonstration und Testen des Healthbar Features für die Energy einer Node bzw. dessen Verbrauch beim Senden einer Nachricht. <br>
![grafik](https://user-images.githubusercontent.com/77550792/203973781-94a2f001-b5fc-4ff4-b612-8040182dd476.png)
- Grid-Demo: Demonstration der Ausbreitung von Nachrichten in einem Grid mit unterschiedlichen Nodetypen <br>
![grafik](https://user-images.githubusercontent.com/77550792/203974664-62cb31ee-2784-4a4f-a69e-47c3ed774f04.png)
- Wildfire: Simulation einer Waldbrand Situation, wo eine Node Über eine Bundesstraße vom Feuer wegfährt und alle Nodes auf dem Weg warnt, damit diese auch flüchten können. <br>
![grafik](https://user-images.githubusercontent.com/77550792/203975540-55aa9d0f-267c-43fc-b8bb-a130d0c19dcb.png)
- dam_crack: Simulation eines Dammbruchs an der Mosel in Koblenz. Schwerpunkt liegt hier auf den THW Nodes, die am Moselufer patrolieren und alle anderen Nodes warnen, wenn sie in die Nähe kommen. So können sich fast alle Nodes aus der Nähe der Mosel entfernen. <br>
![grafik](https://user-images.githubusercontent.com/77550792/203975033-87139337-008a-4fd0-9063-7d63a5c63df8.png)

### Nachrichtentypen

Verschickte Nachrichten werden farblich anhand ihres Types Markiert. Diese Farben sind konsistent mit den [Nodefarben](#nodetypen). <br>
Folgende Typen gibt es:
- allgemeine Nachricht / Vorlage: Dieser Typ ist nicht zum Versenden gedacht, sondern wird als Gemeinsames Objekt für alle Nachrichten genutzt. Alle MessageDot Prefabs erben von ihm <br>
![grafik](https://user-images.githubusercontent.com/77550792/204012696-e6833cb6-4b36-447c-b15b-87eac8765a76.png)
- Bluetooth Nachricht: Diese Typ wird zum Versenden von Bluetooth Nachrichten benutzt. <br>
![grafik](https://user-images.githubusercontent.com/77550792/204012813-11b239da-9784-4d5c-ad3b-2c6f0351d5dc.png)
- Funkturm Nachricht: Dieser Typ wird zum Versenden von Funkturm / Cellular Broadcast Nachrichten benutzt. <br>
![grafik](https://user-images.githubusercontent.com/77550792/204012248-d1c741bc-91a6-44e7-88ac-91a2f3fac9a9.png)
- W-Lan / WiFi Nachricht: Dieser Typ wird zum versenden von WiFi Nachrichten benutzt. <br>
![grafik](https://user-images.githubusercontent.com/77550792/204012503-a942d05b-7a4a-483d-8c38-fa17323b3cc5.png)


### Nodetypen

Nodes Repräsentieren Endpunkte und Geräte in der Kommunikation. Sie können verschiedene Nachrichtentypen empfangen und senden. Manche Nodes können auch Nachrichten erstellen. <br>
Die Farben der Nodes orientieren sich an denen der unterstützen Nachrichtentypen. <br>
Alle Nodes haben Energybalken, die verbraucht werden beim Senden von Nachrichten. <br>
Folgende Nodetypen gibt es:
- Node God: Diese Node ist eine allmächtige Node, die alle Kommunikationstypen empfangen und senden kann. Sie ist nicht für den Einsatz in der Simulation gedacht, sondern dient als Basis aller anderen Nodes. Verändert man ein Attribut in dieser, so verändert man es in allen Nodes. <br>
![grafik](https://user-images.githubusercontent.com/77550792/206210425-d1dfdc99-2bc9-45e5-9612-3b9fe0cdcf34.png)
- Node Funkturm: Diese Node kann nur Cellular Nachrichten versenden und empfangen. Das Empfangen ist aber kein realistischer Zweck, sondern eher zum Testen. Funktürme können mit Hilfe des Skripts [Create Message Script](/Simulation/Assets/Scripts/MessageDot/createMessageScript.cs) im [Inspector](#inspector) Nachrichten erstellen, wie in [Erstellen von Nachrichten](#erstellen-von-nachrichten) beschrieben.<br>
![grafik](https://user-images.githubusercontent.com/77550792/206214336-eb30c435-67f4-490f-ba9e-38660ff53fd1.png)
- Node BTOnly: Diese Node kann nur Bluetooth Nachrichten empfangen und senden. <br>
![grafik](https://user-images.githubusercontent.com/77550792/206211330-0882b257-2c3b-4cd4-91dc-1d00a4f46a22.png)
- Node BT+getCell: Diese Node kann Bluetooth und Cellular Nachrichten empfangen, aber nur Bluetooth Nachrichten wieder versenden. <br>
![grafik](https://user-images.githubusercontent.com/77550792/206218272-c37d2be7-92b7-4f43-8dc6-6f56ff439f4f.png)
- Node WifiOnly: Diese Node kann nur WiFi / WLAN Nachrichten empfangen und senden. <br>
![grafik](https://user-images.githubusercontent.com/77550792/206218569-16b4daa0-5f34-4246-8c1a-41b4cfc0c87e.png)
- Node Wifi+getCell: Diese Node kann WiFi / WLAN und Cellular Nachrichten empfangen, aber nur WiFi / WLAN Nachrichten wieder versenden. <br>
![grafik](https://user-images.githubusercontent.com/77550792/206218833-6a8b3f8e-988e-4a79-958e-8672b07375da.png)
- Node Normal: Diese Node kann Bluetooth, WiFi / WLAN und Cellular Nachrichten empfangen und Bluetooth und WiFi / WLAN Nachrichten wieder versenden. <br>
![grafik](https://user-images.githubusercontent.com/77550792/206219827-d5dbd40d-1932-4dfd-902e-8aca27e95615.png)
- Node THW: Diese Node kann Bluetooth, WiFi / WLAN und Cellular Nachrichten empfangen und Bluetooth und WiFi / WLAN Nachrichten wieder versenden. <br>
Zusätzlich kann sie noch Nachrichten erstellen, mit Hilfe des Skripts [Create Message Script](/Simulation/Assets/Scripts/MessageDot/createMessageScript.cs) im [Inspector](#inspector), wie in [Erstellen von Nachrichten](#erstellen-von-nachrichten) beschrieben.<br>
![grafik](https://user-images.githubusercontent.com/77550792/206220064-6c89e128-e9f1-4e5f-b5c9-dd5e2b6b29e2.png)
- Node Spam: Diese Node kann Bluetooth, WiFi / WLAN und Cellular Nachrichten empfangen und Bluetooth und WiFi / WLAN Nachrichten wieder versenden. <br>
Zusätzlich kann sie aber auch neue Nachrichten spammen, wie in [Erstellen von Nachrichten](#erstellen-von-nachrichten) beschrieben.<br>
Ihr Ziel ist es zuerst ein normales Mitglied im Netzwerk zu sein und dann beim Auslösen das ganze Netzwerk zu überlasten durch eine Masse an Nachrichten. <br>
![grafik](https://user-images.githubusercontent.com/77550792/206220722-67df78c1-f053-4271-b72d-4c8cf618e82f.png)

### Wegpunkte

Als Wegpunkte dienen die Targets in [Assets/Scripts/Waypoint](/Simulation/Assets/Scripts/Waypoint). Diese Können beliebig auf der Karte angelegt werden. Nachbar Wegpunkte werden mit Hilfe des [Waypoint Neighbors](Simulation/Assets/Scripts/Waypoint/WaypointNeighbors.cs) Skript im [Inspector](#inspector) verbunden. Ein Weg kann nur in die Richtung genutzt werden, wie er in der Neighbors Liste ist. Um ihn in beide Richtungen nutzen zu können müssen Targets sich gegenseitig als Nachbarn haben.

Zusätzlich können Wegpunkte auch als Gefahren genutzt werden. Dafür werden sie im [Create Message Script](/Simulation/Assets/Scripts/MessageDot/createMessageScript.cs) einfach in der Liste `Danger Nodes` als Element eingefügt. <br>
Alle Nodes, die diese Nachricht dann bekommen, versuchen auf den Wegen der anderen Wegpunkte möglichst weit von den Gefahrpunkten zu fliehen. <br>
THW Nodes haben allerdings auch einen Modus, wo sie zur Gefahr hinlaufen. Diese Patrollieren dann zufällig zwischen den ihnen bekannten Gefahren.

## Referenzen

Bei der Entwicklung haben wir den Dispatcher aus folgendem Repository benutzt: [UnityToolbag](https://github.com/kellygravelyn/UnityToolbag)

## Disclaimer

Uns ist bewusst, dass der Code und der Aufbau in keinster Weise dem Anspruch eines Production Codes entspricht, dies war aber auch nicht unser Ziel. <br>
Wichtig war uns, unsere Architektur damit Veranschaulichen zu können. Sicherheit, Lesbarkeit und Nutzbarkeit standen da etwas im Hintergrund.

