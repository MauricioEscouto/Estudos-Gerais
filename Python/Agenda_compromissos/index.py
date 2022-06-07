numero_dias = 1
teste = 0
hora = 0
numero_compromissos = 1

print("-"*5 +"Bem-Vindo a sua agenda"+"-"*5+"\n")
print("Sua agenda parece um pouco vazia, deseja cadastrar um compromisso?\n")
pergunta = input("Responda com 'S' para 'sim': ").lower()
print("")

if pergunta == "s":
  mes = input("Insira o mês: ").upper()
  meses = [[mes]]
  numero_dias = int(input("Insira o dia: "))
  hora = float(input("Insira a hora: "))
  compromisso = {'Horário':hora}
  dias = [['Dia',numero_dias]]
  dias.append(compromisso)
  meses[0].append(dias)
  dias[0][1] =  0 + numero_dias
  print("\nSeu compromisso foi agendado com sucesso!")
  
print("")
print("-"*10+"SUA AGENDA"+"-"*10)
print(f'Você possui {numero_compromissos} compromisso cadastrado\n')
print("Para visualizar seus compromissos marcados, digite [1]")
print("Para cadastrar um novo compromisso, digite [2]")
print("Para excluir um compromisso marcado, digite [3]")
pergunta = int(input("Qual opção você deseja? "))
print("")

if pergunta == 1:
  print(f'Seus compromissos: {meses}')

if pergunta == 2:
  while pergunta == 2:
    mes2 = input("Insira o mês: ")
    meses.append(mes2)
    numero_dias = int(input("Insira o dia: "))
    hora = float(input("Insira a hora: "))
    compromisso = {'Hora':hora}
    dias = [['Dia',numero_dias]]
    dias.append(compromisso)
    meses.append(dias)
    dias[0][1] =  0 + numero_dias
    print("\nSeu compromisso foi agendado com sucesso!\n")
    pergunta = input("Deseja cadastrar um novo compromisso? ")