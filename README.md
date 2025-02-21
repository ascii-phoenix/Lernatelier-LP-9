# Lernatelier-LP-9
## 14.02.2005
- [x] Test schreiben
- [x] Igamobjekt , Position und vector erstellen
- [x] BilliardBall und CueBall erstellen
- [x] UnmovableLine erstellen

Heute habe ich mich nach reiflicher Überlegung entschieden, die Billardphysik anders zu gestalten. Ich habe mich entschieden, dies durch Berechnungen umzusetzen, anstatt auf Pixelüberlappung zu achten. Der Vorteil ist, dass der Ball so schnell kommen kann, wie er soll, und es wird erkannt. Es gibt eine Trennung zwischen Physik und Grafik.
Leider gibt es noch ein Paar Fehler
## 21.02.2005
- [x] bugfix bei CheckCollision_ShouldDetectCollision Test
- [x] bugfix bei GamePhysics_CheckCollision_ShouldHandleMultipleObjects Test
- [x] bugfix bei HitChangeVelocity_ShouldReverseVelocityOnCollision Test
- [x] bugfix bie UpdatePosition_ShouldApplyFriction Test

Heute habe ich mehrere Bugs in der Kollisionslogik behoben. Besonders die Tests für die Kollisionserkennung und die Geschwindigkeitsänderung nach einem Treffer wurden verbessert. Die Tests zeigen nun das erwartete Verhalten, was zu stabileren Physikberechnungen führt.
