import medicamentos

medicamentos_lista = ["SINGULAIR","CO-RENITEC", "QUICARD"]
teclado = input("Informe o nome do medicamento: ")
teclado = teclado.upper()

print("")
while teclado != medicamentos_lista:
  if teclado == "SINGULAIR":
    medicamentos.medicamento_1()
    break
  elif teclado == "CO-RENITEC":
    medicamentos.medicamento2()
    pergunta = input("Deseja consultar outro medicamento? Responda com |S| para Sim ou |N| para não: ").upper()
    if pergunta == "S": 
      teclado = input("Informe o nome do medicamento: ").upper()
    elif pergunta == "N":
      break
  elif teclado == "QUICARD":
    medicamentos.medicamento3()
    break
  else:
    teclado = input("O medicamento não existe, favor insira novamente: ")
