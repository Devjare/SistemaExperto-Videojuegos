videojuego("gta v").
videojuego("zenith").
videojuego("zelda").
videojuego("halo").
videojuego("dragon ball fighter z").
videojuego("overwatch").
videojuego("marvel ultimate alliance").
videojuego("marvel heroes omega").
videojuego("call of duty modern warfare 2").
videojuego("sonic").
videojuego("yoshi island").
videojuego("street fighter 2").
videojuego("super mario bros 1").
videojuego("doom").
videojuego("resident evil remake").
videojuego("left 4 dead 2").

es_genero("gta v", "accion").
es_genero("zenith", "accion rpg").
es_genero("zelda", "accion").
es_genero("halo", "accion").
es_genero("dragon ball fighter z", "ciencia ficcion").
es_genero("overwatch", "accion").
es_genero("marvel ultimate alliance", "accion").
es_genero("marvel heroes omega", "mmorpg").
es_genero("call of duty modern warfare 2", "guerra").
es_genero("sonic", "plataformas").
es_genero("yoshi island", "plataformas").
es_genero("street fighter 2", "accion").
es_genero("super mario bros 1", "plataformas").
es_genero("doom", "accion").
es_genero("resident evil remake", "accion").
es_genero("left 4 dead 2", "ciencia ficcion").

es_tema("gta v", "oeste").
es_tema("zenith", "fantasia").
es_tema("zelda", "aventura").
es_tema("halo", "fps").
es_tema("dragon ball fighter z", "lucha").
es_tema("overwatch", "fps").
es_tema("marvel ultimate alliance", "superheroes").
es_tema("marvel heroes omega", "superheroes").
es_tema("call of duty modern warfare 2", "fps").
es_tema("sonic", "fantasias").
es_tema("yoshi island", "fantasias").
es_tema("street fighter 2", "lucha").
es_tema("super mario bros 1", "fantasia").
es_tema("doom", "aventura").
es_tema("resident evil remake", "terror").
es_tema("left 4 dead 2", "terror").

lanzado_el("Gta v ", "2014").
lanzado_el("Zenith", "2016").
lanzado_el("Zelda", "1998").
lanzado_el("halo", "2011").
lanzado_el("Dragon ball fighter z", "2018").
lanzado_el("Overwatch", "2019").
lanzado_el("Marvel ultimate alliance", "2006").
lanzado_el("Marvel heroes omega", "2017").
lanzado_el("Call of duty modern warfare 2", "2007").
lanzado_el("Sonic", "2005").
lanzado_el("Yoshi island", "1995").
lanzado_el("Street fighter 2", "2011").
lanzado_el("Super mario bros 1", "2013").
lanzado_el("Doom", "2017").
lanzado_el("Resident evil remake", "2019").
lanzado_el("Left 4 dead 2", "2009").

desarrollado_por("gta V", "rockstar games").
desarrollado_por("zenith", "badland games").
desarrollado_por("zelda", "Nintendo").
desarrollado_por("Halo", "242 insdutries").
desarrollado_por("dragon ball fighter z", "arc system works").
desarrollado_por("overwatch", "bizzard entertaiment").
desarrollado_por("marvel ultimate alliance", "raven software").
desarrollado_por("marvel heroes omega", "gazillon entertaiment").
desarrollado_por("call of duty modern warfare 2", "n space").
desarrollado_por("sonic", "sonic team").
desarrollado_por("yoshi island", "nintendo").
desarrollado_por("street fighter 2", "capcom").
desarrollado_por("super mario bros 1", "nintendo").
desarrollado_por("doom", "panic button").
desarrollado_por("resident evil remake", "capcom").
desarrollado_por("Left 4 Dead", "Turtle Rock Studios").

personaje_de("Trevor", "GTA V").
personaje_de("Franklin", "GTA V").
personaje_de("Argus", "Zenith").
personaje_de("Mago Aventurero", "Zenith").
personaje_de("Elfos", "Zenith").
personaje_de("link", "zelda").
personaje_de("navi", "zelda").
personaje_de("prrincesa zelda", "zelda").
personaje_de("halo", "cortana").
personaje_de("halo", "jefe maestro").
personaje_de("halo", "jacob keyes").
personaje_de("halo", "avery").
personaje_de("dragon ball fighter z", "hit").
personaje_de("dragon ball fighter z", "goku").
personaje_de("dragon ball fighter z", "freezer").
personaje_de("dragon ball fighter z", "vegeta").
personaje_de("dragon ball fighter z", "krillin").
personaje_de("overwatch", "orisa").
personaje_de("overwatch", "reinhartd").
personaje_de("overwatch", "roadhog").
personaje_de("overwatch", "sigma").
personaje_de("overwatch", "winston").
personaje_de("marvel ultimate alliance", "capitan america").
personaje_de("marvel ultimate alliance", "spider man").
personaje_de("marvel ultimate alliance", "wolverin").
personaje_de("marvel ultimate alliance", "thor").
personaje_de("marvel heroes omega", "capitan america").
personaje_de("marvel heroes omega", "thanos").
personaje_de("marvel heroes omega", "iron man").
personaje_de("marvel heroes omega", "thor").
personaje_de("call of duty modern warfare 2", "joseph").
personaje_de("call of duty modern warfare 2", "soldado").
personaje_de("call of duty modern warfare 2", "james").
personaje_de("sonic", "sonic").
personaje_de("yoshi island", "yoshi").
personaje_de("yoshi island", "mario bros").
personaje_de("yoshi island", "luigi").
personaje_de("yoshi island", "kamek").
personaje_de("street fighter 2", "ryu").
personaje_de("street fighter 2", "e honda").
personaje_de("street fighter 2", "vega").
personaje_de("street fighter 2", "chun li").
personaje_de("street fighter 2", "ken").
personaje_de("super mario bros 1", "mario bros").
personaje_de("super mario bros 1", "yoshi").
personaje_de("super mario bros 1", "peach").
personaje_de("super mario bros 1", "daisy").
personaje_de("super mario bros 1", "luigi").
personaje_de("doom", "marine").
personaje_de("resident evil remake", "leon").
personaje_de("resident evil remake", "claire").
personaje_de("resident evil remake", "zombie").
personaje_de("resident evil remake", "").
personaje_de("left 4 dead 2", "nick").
personaje_de("left 4 dead 2", "ellis").
personaje_de("left 4 dead 2", "rochelle").
personaje_de("left 4 dead 2", "coach").
personaje_de("left 4 dead 2", "zombie").


%   RULES
%   Videojuegos que salieron en FECHA, de GENERO.
videojuego_genero_fecha(X, FECHA,GENERO):- lanzado_el(X, FECHA), es_genero(X, GENERO).
%  Personajes de videojuegos que salieron en FECHA, de GENERO.
personajes_videojuego_genero_fecha(X, FECHA, GENERO, Y):- lanzado_el(X, FECHA), es_genero(X, GENERO), personaje_de(Y, X).

