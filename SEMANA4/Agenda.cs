﻿
Console.WriteLine("Universidad Estatal Amazónica");
Console.WriteLine("=============================");
Console.WriteLine();

RegistroContactos registro = new RegistroContactos(20);

Contacto uno = new Contacto("Alex", 0965321020);
Contacto dos = new Contacto("Lucas", 0986523140);
Contacto tres = new Contacto("Lorena", 0965321478);

registro.IngresoNuevocontacto(uno, 0);
registro.IngresoNuevocontacto(dos, 1);
registro.IngresoNuevocontacto(tres, 2);

registro.imprimirnombres();

Console.WriteLine("Ingrese el nombre del contacto a buscar");
registro.buscar(Console.ReadLine());

