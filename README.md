# Simulation

Simulation für unser Projektpraktikum

Diese Simulation simuliert unsere Architektur für eine Katastrophenkommunikation.

Realisiert wird dies mit Unity.

## Unity

Benötigt wird Version 2020.3.7f1

Am einfachsten Installiert über [Unity Hub](https://unity.com/download) mit Download der Version aus dem [Archiv](https://unity3d.com/get-unity/download/archive) <br>
Getestet wurde es mit Windows und Fedora (Download Unity Hub über [Flathub](https://flathub.org/apps/details/com.unity.UnityHub))

## Projekt importieren in Unity

Der Ordner [Simulation](/Simulation) ist ein Unity Projekt und kann als solches einfach in Unity Hub importiert werden. <br>
Von Dort kann es dann auch mit einfachem klick gestartet werden.

## Inhalt und Starten der Simulationen

Wenn Unity gestartet ist, so kann man unten Rechts und unten Mitte den Projektinhalt sehen.
![grafik](https://user-images.githubusercontent.com/77550792/203961108-56b0486d-4da9-48c0-a593-fba13c2bb564.png)

### Projektübersicht

Wichtig davon sind folgende Ordner:
- [Assets/Scenes](/Simulation/Assets/Scenes): Hier liegen unsere Szenen drin, welche aus Szenarios und Test/Debug Szenen bestehen.
- [Assets/Scripts/MessageDot](/Simulation/Assets/Scripts/MessageDot): Hier befinden sich die Scripte und Prefabs für die Nachrichten drin.
- [Assets/Scripts/Node](/Simulation/Assets/Scripts/Node): Hier befinden sich die Scripte und Prefabs für die Nodes drin.
- [Assets/Scripts/Waypoint](/Simulation/Assets/Scripts/Waypoint): Hier befinden sich die Scripte und Prefabs für die Wegpunkte drin. Diese können bei sowohl bei Nodes zur Wegffindung genutzt werden, als auch in Nachrichten als Gefahrenquellen.

### Hierarchy

TODO

### Inspector

TODO

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

### Nachrichten Typen

TODO

### Node Typen

TODO

### UI / Camera

TODO

## Referenzen

Bei der Entwicklung haben wir den Dispatcher aus folgendem Repository benutzt: [UnityToolbag](https://github.com/kellygravelyn/UnityToolbag)

## Disclaimer

Uns ist bewusst, dass der Code und der Aufbau in keinster Weise dem Anspruch eines Production Codes entspricht, dies war aber auch nicht unser Ziel. <br>
Wichtig war uns, unsere Architektur damit Veranschaulichen zu können. Sicherheit, Lesbarkeit und Nutzbarkeit standen da etwas im Hintergrund.

