# FeerikGames-TechnicalTest<br/><br/>

### Fonctionnalités implémentées <br/>
&emsp; - Ouverture de l'éditeur en cliquant sur Window -> Custom -> Show Gizmos in Scene.<br/>
&emsp; - Ouverture de l'éditeur en séléctionnant le fichier "Scene Gizmo Asset.asset" dans le dossier Asset/Data/Editor. <br/>
&emsp; - Affichage des noms et positions des gizmos dans l'éditeur.<br/>
&emsp; - Les gizmos sont representés par des sphères blanches.<br/>
&emsp; - Le nom de l'object apparait lorsque l'object est séléctionné.<br/>
&emsp; - Clic gauche sur une gizmo pour le séléctionné.<br/>
&emsp; - Il est possible de modifier le nom et la position d'un gizmo depuis l'éditeur via les zones de texte et le bouton "Edit" pour valider.<br/>
&emsp; - Une fois séléctionné, il est possible de déplacer le gizmo de manière classique. Sa position se met à jour automatiquement sur l'éditeur.<br/>
&emsp; - Une fois séléctionné, il est possible de faire un clic droit pour :<br/>
&emsp;&emsp; - Remettre le gizmo à sa position initiale.<br/>
&emsp;&emsp; - Supprimer le gizmo.<br/>
&emsp; - Appuyer sur ctrl+z permet de supprimer le dernier changement de position.<br/>

### Choix de conception <br/>
&emsp; - La map se trouve dans la scène nommée "GizmoTestScene" mais les gizmos peuvent être utilisés dans n'importe quelle scène.<br/>
&emsp; - Les gizmos apparaissent à l'ouverture de l'éditeur et sont supprimés à la fermeture.<br/>
&emsp; - L'éditeur reste ouvert tant que le fichier "Scene Gizmo Asset.asset" est séléctionné. Le déselectionner permettra donc de fermer la fenêtre.<br/>

### Problèmes restants <br/>
Il n'est pas très simple de modifier la position d'un gizmo directement depuis l'éditeur puis le bouton "Edit" pour une raison de conversion entre string et float. Il faut toujours qu'il reste dans la zone de texte un caractère que l'on peut convertir en float.<br/>

Lorsque l'on séléctionne une sphère et que l'on fait un clic droit pour afficher le menu puis un clic gauche pour séléctionner l'action à effectuer, l'editeur reste bloqué en vue orbitale. Cela empêche alors l'utilisateur de séléctionner simplement une autre sphère. Ce problème ne semble pas avoir été résolu sur la version 2019.4.32. Malheureusement, changer la vue depuis le script ne fonctionne pas non plus. Il est donc possible de séléctionner les spheres en cliquant directement sur le nom ou bien de passer en mode jeu puis de revenir en mode scene pour fix ce bug.
