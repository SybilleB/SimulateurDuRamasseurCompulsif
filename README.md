# Le Simulateur du Ramasseur Compulsif

> Un créateur de personnage RPG humoristique où l'inventaire compte plus que la quête.

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![AvaloniaUI](https://img.shields.io/badge/Avalonia-B74AF7?style=for-the-badge&logo=avalonia&logoColor=white)

## Présentation

Le **Simulateur du Ramasseur Compulsif** est une application de bureau développée en **C#** avec le framework **Avalonia UI**. 

Le but ? Créer un héros de RPG fantastique et générer aléatoirement un inventaire rempli d'objets loufoques, allant du "T-shirt J'aime ma maman" à "La Couronne du Roi Mendiant". Le projet met l'accent sur une interface utilisateur soignée et une architecture orientée objet solide.

## Fonctionnalités Principales

### Création de Personnage Avancée
- **5 Races** : Humain, Elfe, Nain, Gobelin, Fée.
- **5 Classes** : Guerrier, Mage, Voleur, Alchimiste, Troubadour.
- **Logique de Restrictions** : Certaines races ne peuvent pas exercer certaines classes (ex: un Gobelin ne peut pas être Mage).
- **Système d'Affinités** : Bonus de statistiques si la combinaison Race/Classe est cohérente (ex: Elfe + Voleur).
- **Identité du Héros** : Choix du nom et attribution d'un titre honorifique. Le joueur peut choisir un titre généré aléatoirement (ex: "Le porteur de poisse") ou saisir un titre personnalisé.

### Système de Statistiques
Le cœur du héros repose sur ses caractéristiques, définies par un mélange de chance et d'optimisation :
- ** Six attributs clés** : Force, Agilité, Vitalité, Intelligence, Charisme, Chance.
- **Lancer de Dés (RNG)** : Simulation de jets de deux dés de 6 pour déterminer les valeurs des attributs.
- **Calcul Dynamique** : Les statistiques finales sont calculées en temps réel en additionnant les jets de dés et les bonus passifs liés à la Race et la Classe. *Exemple* : Un Nain recevra automatiquement un bonus en *Vitalité*, tandis qu'un Mage verra son *Intelligence* boostée, quelle que soit la valeur des dés.
- **Visualisation** : Affichage clair de la répartition des points pour évaluer la puissance du personnage.

### Gestion d'Inventaire Aléatoire (RNG)
- Génération d'objets avec **4 niveaux de rareté** (Commun, Rare, Épique, Légendaire).
- Le type d'objet (Armure, Livre, Potion...) s'adapte automatiquement à la classe choisie.
- Descriptions humoristiques pour chaque item.


### Import d'Avatar
- Importation d'images personnalisées (PNG/JPEG) via l'explorateur de fichiers natif du système.

## Architecture Technique

Le projet utilise des concepts de Programmation Orientée Objet (POO) pour assurer la maintenabilité :

* **Polymorphisme & Héritage** : Utilisation de méthodes virtual et override (classeAutorisee, classeFavorite) dans les classes de Races. Utilisation de classes mères (Race, HerosClasse) et de classes filles (Humain, Elfe, Mage, Troubadour...).
* **Génération Dynamique** : Les objets de l'inventaire sont créés dynamiquement via des dictionnaires et des énumérations (TypeItem, Rarete).

* **Avalonia UI** : Utilisation de XAML pour le design, avec des Styles, des Templates et des UserControls pour une navigation simplifiée.

## Prérequis et conseils
Avoir le SDK .NET 9.0 installé.

Par défaut, l'application mesure 1600x900px. Afin d'optimiser votre expérience, nous vous recommandons de l'ouvrir en **plein écran** si vous possédez un écran de moins de 24 pouces.

## Lancement 
1. Cloner le dépôt : 
```bash
  git clone https://github.com/SybilleB/SimulateurDuRamasseurCompulsif.git
```
2. Ouvrir le projet dans Rider ou Visual Studio
3. Compiler et lancer : 
```bash
  dotnet run
```

### À propos des développeurs
Ce projet a été développé par **Sybille BRASSIER** et **Maïlys DAGUERRE**, dans le cadre d'un apprentissage approfondi du langage C# et du framework Avalonia UI, sous la supervision de **M. Benoit ESTIVAL**.

> *Ce projet a été propulsé avec beaucoup (jamais assez) de patience, une quantité industrielle de boissons énergisantes qui donnent des ailes, et une passion communes pour les jeux vidéo.*