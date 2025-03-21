# Lernatelier-LP-9
## 14.02.2025
- [x] Test schreiben
- [x] Igamobjekt , Position und vector erstellen
- [x] BilliardBall und CueBall erstellen
- [x] UnmovableLine erstellen

Heute habe ich mich nach reiflicher Überlegung entschieden, die Billardphysik anders zu gestalten. Ich habe mich entschieden, dies durch Berechnungen umzusetzen, anstatt auf Pixelüberlappung zu achten. Der Vorteil ist, dass der Ball so schnell kommen kann, wie er soll, und es wird erkannt. Es gibt eine Trennung zwischen Physik und Grafik.
Leider gibt es noch ein Paar Fehler
## 21.02.2025
- [x] bugfix bei CheckCollision_ShouldDetectCollision Test
- [x] bugfix bei GamePhysics_CheckCollision_ShouldHandleMultipleObjects Test
- [x] bugfix bei HitChangeVelocity_ShouldReverseVelocityOnCollision Test
- [x] bugfix bie UpdatePosition_ShouldApplyFriction Test

Heute habe ich mehrere Bugs in der Kollisionslogik behoben. Besonders die Tests für die Kollisionserkennung und die Geschwindigkeitsänderung nach einem Treffer wurden verbessert. Die Tests zeigen nun das erwartete Verhalten, was zu stabileren Physikberechnungen führt.
## 28.02.2025
- [x] Test für Cueball
- [x] Cueball programieren
- [x] Cueball bugfixes
- [x] alle Klassen nach Biliard tansformieren
Heute habe ich die Implementierung des Cueballs abgeschlossen und sichergestellt, dass alle Klassen konsistent mit der Billardlogik sind. Die Tests für den Cueball wurden erfolgreich durchgeführt, und alle bekannten Fehler wurden behoben. Die Umstellung auf eine berechnungsbasierte Physik hat sich als vorteilhaft erwiesen, da sie präzisere und vorhersehbarere Ergebnisse liefert.
## 07.03.2025
- [x] Test für Cuestick
- [x] Cuestick programieren
- [ ] Cuestick bugfixes
- [ ] maus mit cuestick verbinden
Heute habe ich den Cuestick implementiert und grundlegende Tests durchgeführt. Der Stick interagiert bereits mit dem Cueball, jedoch gibt es noch einige Ungenauigkeiten in der Kollision und Bewegungsberechnung. Die Maussteuerung wurde noch nicht implementiert, was ein nächster wichtiger Schritt sein wird. Zunächst werde ich jedoch bestehende Fehler beheben, um eine stabile Basis für die Steuerung zu schaffen.
## 14.03.2025
- [x] Cuestick bugfixes
- [x] Maus mit cuestick verbinden
- [x] Test für Mehrere kolisionen
- [x] Liste für Treffen aufbauen
Heute habe ich die Maussteuerung für den Cuestick implementiert und Fehler in der Kollisionslogik behoben. Zudem speichert eine Liste nun alle Kollisionen, um Mehrfachtreffer besser zu analysieren. Die Physik läuft stabiler, kleine Ungenauigkeiten bleiben jedoch.
## 21.03.2025
Ich habe mich am 21.03.2025 auf LeetCode in Python 3.11 fokussiert, um die Aufgaben des Moduls 259 (Entwicklung von IT-Lösungen mithilfe von Machine Learning) auszuführen. Ich habe die nachfolgenden LeetCode-Aufgaben bearbeitet: 
- Aufgabe 2
- Aufgabe 26 (diese musste aufgrund der Methode neu geschrieben werden.Clear() sind in Python 3.11 nicht in Listen erhältlich.)
- Aufgabe 50 (die mit einer rekursiven Lösung gelöst wurde) 
- Aufgabe 58
- Aufgabe 69 (die Aufgabe wurde hier nicht vollständig erfüllt)
- Aufgabe 70 (die sich ausschließlich auf die Fibonacci-Reihe bezog)
