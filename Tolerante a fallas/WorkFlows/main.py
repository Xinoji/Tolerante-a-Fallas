import requests
from bs4 import BeautifulSoup
from datetime import date
from prefect import task, Flow


@task
def getData():
    url = 'https://www.banxico.org.mx/tipcamb/tipCamMIAction.do'
    response = requests.get(url)
    soup = BeautifulSoup(response.content, 'html.parser')

    data = soup.find('tr', {'class': 'renglonNon'})
    datas = data.find_all('td')

    return float(datas[-1].text.strip())

@task
def transformData(data):
    Savings = 20
    return 20 * data

@task
def result(res):
    msg = "Actualmente los dolares ahorrados son: " + str(res)
    with open("ahorro.txt", 'a') as f:
        f.write(msg)
    return msg

def build_flow():
    with Flow("first_flow") as f:
        data = getData()
        res = transformData(data)
        print(result(res))

    return f

build_flow().run()

