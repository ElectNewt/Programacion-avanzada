# Chuleta para expresiones regulares

## Comprobar caracteres
caracter | descripcion | Ejemplo | resultado
:--- |:--- | :---: | ---:
`\d` | Comprueba un número de 0 a 9 | test\d\d | test01
`\w` | Comprueba una letra | t\w\wt | test
`\s` | Comprueba un espacio en blanco  | test\s01 | test 01
`\D` | Cualquier carácter que no sea un número | te\D\D | test
`\W` | Cualquer carácter que no sea una letra | \W\W  | +-
`\S` | Todo lo que no sea espacios en blanco | Test\S1 | test01
`.` | Cualquier carácter excepto salto de línea | test.1 | test01
`\.` | Escapar el punto para detectar un punto | test\.01 | test.01
`\` | escapa un caracter especial | \[\(\{\.\*\?\+\$\^\/\\\}\)\] | [({.*?+$^/\\})]
`^` | principo de línea | ^Frase | Frase
`|` | operador `or` o uno o tro | test|frase | frase
`$` | final de línea | test$ | ...test

### Otros dentro de los caracteres
caracter | descripcion 
:--- |:--- 
`\t` | tabs 
`\r` | caracter de retorno 
`n` | nueva línea
`\n\r` | salto de línea en windows



## Cuantificadores/ número de repeticiones
caracter | descripcion | Ejemplo | resultado
:--- |:--- | :---: | ---:
`*` | cero o más veces | test\d* | test23456
`?` | cero o una vez | test\d? | test
`+` | uno o mas | test\d+ | test01
`{2}` | número exacto de veces  | test\d{2} | test01
`{n,m}` | de n a m veces | test\d{2,4} | test12 o test1234 
`{2,}` | Número de veces o más (dos o mas en el ejemplo) | test\d{2,} | test123


## Agrupaciones
caracter | descripcion | Ejemplo | resultado
:--- |:--- | :---: | ---:
`[]` | defeinicion de agrupación | [\d\d\w] | 1 
`[n-m]` | rango de n a m | [a-z]{4} | hola
`[^]` | que no este en la agrupación | [^a-z]{4} | 1234



