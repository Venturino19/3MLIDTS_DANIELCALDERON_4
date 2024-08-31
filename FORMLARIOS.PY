import tkinter as tk
from tkinter import messagebox

def limpiar_campos():
    tbNombre.delete(0, tk.END)
    tbApellidos.delete(0, tk.END)
    tbEdad.delete(0, tk.END)
    tbEstatura.delete(0, tk.END)
    tbTelefono.delete(0, tk.END)
    var_genero.set(0)

def guardar_valores():
    nombres = tbNombre.get()
    apellidos = tbApellidos.get()
    edad = tbEdad.get()
    estatura = tbEstatura.get()
    telefono = tbTelefono.get()
    genero = ""
    if var_genero.get() == 1:
        genero = "Hombre"
    elif var_genero.get() == 2:
        genero = "Mujer"

    datos = (
        f"Nombres: {nombres}\n"
        f"Apellidos: {apellidos}\n"
        f"Edad: {edad} años\n"
        f"Estatura: {estatura}\n"
        f"Telefono: {telefono}\n"
        f"Genero: {genero}\n"
    )

    with open("datos_formulario.txt", "w") as file:
        file.write(datos)

    messagebox.showinfo("Éxito", "Los datos se han guardado correctamente.")
    rbHombre.config(state=tk.DISABLED)
    rbMujer.config(state=tk.DISABLED)

def borrar():
    limpiar_campos()

ventana = tk.Tk()
var_genero = tk.IntVar()
ventana.geometry("720x500")
ventana.title("Formulario Vr.01")

lbNombre = tk.Label(ventana, text="Nombres :")
lbNombre.pack()
tbNombre = tk.Entry(ventana)
tbNombre.pack()

lbApellidos = tk.Label(ventana, text="Apellidos :")
lbApellidos.pack()
tbApellidos = tk.Entry(ventana)
tbApellidos.pack()

lbTelefono = tk.Label(ventana, text="Telefono :")
lbTelefono.pack()
tbTelefono = tk.Entry(ventana)
tbTelefono.pack()

lbEdad = tk.Label(ventana, text="Edad :")
lbEdad.pack()
tbEdad = tk.Entry(ventana)
tbEdad.pack()

lbEstatura = tk.Label(ventana, text="Estatura :")
lbEstatura.pack()
tbEstatura = tk.Entry(ventana)
tbEstatura.pack()

lbGenero = tk.Label(ventana, text="Genero")
lbGenero.pack()
rbHombre = tk.Radiobutton(ventana, text="Hombre", variable=var_genero, value=1)
rbHombre.pack()
rbMujer = tk.Radiobutton(ventana, text="Mujer", variable=var_genero, value=2)
rbMujer.pack()

btnGuardar = tk.Button(ventana, text="Guardar", command=guardar_valores)
btnGuardar.pack()

btnBorrar = tk.Button(ventana, text="Borrar", command=borrar)
btnBorrar.pack()

ventana.mainloop()
