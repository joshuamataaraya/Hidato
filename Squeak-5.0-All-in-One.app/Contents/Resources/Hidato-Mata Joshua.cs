﻿'From Squeak5.0 of 6 August 2015 [latest update: #15113] on 30 October 2015 at 10:19:07 am'!Smalltalk renameClassNamed: #HIidato as: #Hidato!Object subclass: #Hidato	instanceVariableNames: ''	classVariableNames: ''	poolDictionaries: ''	category: 'HidatoClasses'!Hidato class	instanceVariableNames: 'matriz'!Object subclass: #Matriz	instanceVariableNames: 'buttons availableCount myWindow'	classVariableNames: ''	poolDictionaries: ''	category: 'HidatoClasses'!SimpleButtonMorph subclass: #Square	instanceVariableNames: 'xPosition yPosition isPressed num isPlaying isAvailable posibles isVisited matriz'	classVariableNames: 'NumberToSet'	poolDictionaries: ''	category: 'HidatoClasses'!!Hidato class methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 23:18'!AcercaDe	^'INSTITUTO TECNOLOGICO DE COSTA RICA.........................HIDATO: Programacion Hecha Por Joshua Mata Araya(2014079095). Es un programa que genera hidatos, permite al jugador usarlo y ademas revisa si el jugador logró ganar el juego.'! !!Hidato class methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 23:33'!Ayuda	^'De esta misma clase ejecute los metodos de DefinirCasillas (para seleccionar cuales casillas se desean usar del hidato), crearHidato:numeroPorQuitar (para que el programa genere el hidato) y una vez que se termina el juego, ejecutar revisarHidato (para revisar que el usuarios haya ganado o no el hidato. ES IMPORTANTE NO LLAMAR AL METODO DE CREAR HIDATO SI NO SE HA EJECUTADO EL METODO DE DEFINIR CASILLAS. CUANDO SE EJECUTE LA FUNCION DE DEFINIRCASILLAS, ES NECESARIO MARCAR SIEMPRE LA PRIMERA CASILLA, YA QUE A PARTIR DE ESTA SE GENERA EL HIDATO.'! !!Hidato class methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 23:24'!DefinirCasillas	matriz:= (Matriz new).! !!Hidato class methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 23:26'!crearHidato:numeroPorQuitar	matriz startPlaying.	matriz setNums.	matriz quitarAlgunas:numeroPorQuitar.		! !!Hidato class methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 23:28'!revisarHidato	"devuelve un valor booleano si el hidato creado por el usuario es correcto o no."	^matriz verificaGane.! !!Matriz methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:52'!buttons	^buttons! !!Matriz methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 16:07'!initialize	|x y model |	super initialize.		model := Model new.       myWindow := SystemWindow new.       myWindow model: model.      	x:=20.	y:=20.	buttons:= Array new: 10.	1 to: 10 do: [:i| buttons at: i put: (Array new: 10)].		1 to: 10 do: [:i|		1 to: 10 do: [:j|			(buttons at: i) at:j put: (Square new).			((buttons at: i) at:j) X:x Y:y Matriz: self. 			((buttons at: i) at:j) color: Color red.			myWindow addMorph: ((buttons at: i) at:j).			x:=x+50.].		x:=20.		y:=y+50].	Square initValue.	availableCount:=0.			myWindow openInWorld. ! !!Matriz methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:53'!obtenerPosibles: i J:j  	|options x y|	options:=OrderedCollection new:8.	x:=(i-1).	y:=(j-1).	(x>0 and: y>0 and: x<11 and: y<11)	ifTrue:[		options add:((buttons at: x) at:y)].				x:=i.	y:=(j-1).	(x>0 and: y>0 and: x<11 and: y<11)	ifTrue:[		options add:((buttons at: x) at:y)].			x:=(i+1).	y:=(j-1).	(x>0 and: y>0 and: x<11 and: y<11)	ifTrue:[		options add:((buttons at: x) at:y)].			x:=(i-1).	y:=(j).	(x>0 and: y>0 and: x<11 and: y<11)	ifTrue:[		options add:((buttons at: x) at:y)].			x:=(i+1).	y:=(j).	(x>0 and: y>0 and: x<11 and: y<11)	ifTrue:[		options add:((buttons at: x) at:y)].				x:=(i-1).	y:=(j+1).	(x>0 and: y>0 and: x<11 and: y<11)	ifTrue:[		options add:((buttons at: x) at:y)].			x:=(i).	y:=(j+1).	(x>0 and: y>0 and: x<11 and: y<11)	ifTrue:[		options add:((buttons at: x) at:y)].		x:=(i+1).	y:=(j+1).	(x>0 and: y>0 and: x<11 and: y<11)	ifTrue:[		options add:((buttons at: x) at:y)].		^options! !!Matriz methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 16:10'!quitarAlgunas: cantidad 	|cantidadAux x y|	cantidadAux:=cantidad.	cantidad< (availableCount-2)	ifTrue:[	1 to: 10 do: [:i|		1 to: 10 do: [:j|			x:=i\\2.			y:=j\\2.			(((buttons at: i) at:j) isAvailable =True and: cantidadAux>0 and: ((buttons at: i) at:j) num ~=1 and: ((buttons at: i) at:j) num ~= availableCount)			ifTrue:[				(y=0 or: x=0)				ifTrue:[					cantidadAux:=cantidadAux-1.					((buttons at: i) at:j) setNum: 0.					].				].					].	].	]! !!Matriz methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 13:48'!setNums	| inicial|	self setPosibles.	inicial:=((buttons at:1) at:1).	^self setNums: inicial num:1.		! !!Matriz methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 14:16'!setNums: inicial num: n	|posibles numAux|	posibles:= inicial getPosibles.	inicial setNum: n.	(n=availableCount and: (inicial isVisited)=False)	ifTrue:[		^True		]	ifFalse:[		1 to: (posibles size) do:[			:i|			((posibles at:i) isVisited=False and: (posibles at:i) isAvailable=True)			ifTrue:[				numAux:=n+1.				inicial setVisited:True.				(self setNums: (posibles at:i) num: numAux)=True				ifTrue:[					^True					].				] 					].		inicial setVisited:False.		^False		].	! !!Matriz methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:53'!setPosibles 	1 to: 10 do: [:i|		1 to: 10 do: [:j|			((buttons at: i) at:j) isAvailable =True			ifTrue:[				((buttons at: i) at:j) setPosibles: (self obtenerPosibles: i J:j).				].					].	].! !!Matriz methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:53'!startPlaying		1 to: 10 do: [:i|		1 to: 10 do: [:j|			((buttons at: i) at:j) num =1			ifTrue:[				((buttons at: i) at:j) setAvailable:True.				availableCount:=availableCount+1] 			ifFalse:[				((buttons at: i) at:j) setAvailable:False].			((buttons at: i) at:j) startPlaying.			].		].	Square initValue.! !!Matriz methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:53'!verificaGane	|posibles isThere counter|	self setPosibles.	counter:=1.	isThere:=False.	1 to: 10 do: [:i|		1 to: 10 do: [:j|			((buttons at: i) at:j) isAvailable=True			ifTrue:[				counter := ((buttons at: i) at:j) num.				counter:=(counter+1).				posibles:=(((buttons at: i) at:j) getPosibles).				1 to:  (posibles size) do:				[:m|					((posibles at: m) num =counter or: ((buttons at: i) at:j) num=availableCount)					ifTrue:[						isThere:=True.					]													].				isThere=True				ifTrue:[					isThere:=False.				]				ifFalse:[					^False				].			]			 			].	].	^True! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:47'!X^xPosition! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 14:04'!X: posX Y: posY super initialize.xPosition:= posX.yPosition:=posY.isPressed:=False.isPlaying:=False.isAvailable:=True.num:=0.isVisited:=False.self label: (num) printString.self position: xPosition@yPosition.self width: 50.self height: 50.self on: #click send: #setNextValue to:self.	! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 16:06'!X: posX Y: posY Matriz: msuper initialize.matriz=m.xPosition:= posX.yPosition:=posY.isPressed:=False.isPlaying:=False.isAvailable:=True.num:=0.isVisited:=False.self label: (num) printString.self position: xPosition@yPosition.self width: 50.self height: 50.self on: #click send: #setNextValue to:self.	! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:48'!Y^yPosition! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:48'!getPosibles^posibles! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:48'!isAvailable^isAvailable! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 13:25'!isVisited^isVisited! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:48'!num^num! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:48'!setAvailable: boolValue	isAvailable:=boolValue.	isAvailable=True	ifTrue:[		self label: (0) printString.		self width: 50.		self height: 50.		]	ifFalse:[		self color: Color black.		self width: 50.		self height: 50.		].		! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:49'!setNextValue	isPlaying=True	ifTrue:[	isAvailable=True	ifTrue:[	isPressed=True	ifFalse: [		Square incValue.		num:= (Square Number).		self label: (num) printString.		self width: 50.		self height: 50.		isPressed:= True.		]	ifTrue:[Square decValue.		num:= 0.		self label: (num) printString.		self width: 50.		self height: 50.		isPressed:= False.].	]]	ifFalse:[		num:=1.		self label: (num) printString.		self width: 50.		self height: 50.		]! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 13:50'!setNum: val num:=val.self label: (num) printString.		self width: 50.		self height: 50.! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:49'!setPosibles: pposibles	posibles:=pposibles.! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 13:25'!setVisited: val	isVisited:=val! !!Square methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:50'!startPlaying	isPlaying:=True.! !!Square class methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:51'!Number	^NumberToSet! !!Square class methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:51'!decValue	NumberToSet:=(NumberToSet)-1.! !!Square class methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:51'!incValue	NumberToSet:=(NumberToSet)+1.! !!Square class methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:51'!initValue	NumberToSet:=0.! !!Square class methodsFor: 'as yet unclassified' stamp: 'JMA 10/28/2015 11:52'!initValue: val	NumberToSet:=val.! !Matriz removeSelector: #setNums:!