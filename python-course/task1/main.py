import math

global full_name
experience = []
skill = []


# "Say function"
def get_user_info():

    name = input("Hi user!\n Enter your name: ")
    surname = input("Surname: ")
    patronymic = input("Patronymic: ")

    global full_name
    full_name = (surname, name, patronymic)
    print(f"Hello {surname} {name} {patronymic}")


def work():
    print("Enter position ( 3 - max; '0' or 'return' to finish )... ")
    jobs = []
    for i in range(3):
        res = input(f"Position {i + 1} : ")
        if res == "0" or res == "return":
            break
        jobs.append(res)
    print("Jobs:")
    print(*jobs, sep='\n')


def experience_skill():
    print("Your experience in IT : ( '0' or 'return' to finish )... ")

    for i in range(10):
        res = input(f"Exp {i + 1} : ")
        if res == "0" or res == "return":
            break
        experience.append(res)

    print("Your skills in IT : ( '0' or 'return' to finish )... ")

    for i in range(10):
        res = input(f"Skill {i + 1} : ")
        if res == "0" or res == "return":
            break
        skill.append(res)

    print("Experience:")
    print(*experience, sep='\n')
    print("Skills:")
    print(*skill, sep='\n')


def cv():
    get_user_info()
    work()
    experience_skill()

    birth = input("Year of birth: ")
    education = input("Education (school/university): ")
    hobbies = input("Hobbies: ")
    location = input("Location: ")
    salary = input("Salary: ")

    return birth, education, hobbies, location, salary


def print_user_cv(birth_year, location):
    print(f"User: {full_name[0]} {full_name[1][0:1]}.{full_name[2][0:1]}, {birth_year}, {location}")


def calculate_formula(x, y):
    part1 = math.pow(1 + x, y)
    part2 = (y * x) / math.factorial(1)
    part3 = (y * (y - 1) * x * x) / math.factorial(2)
    part4 = math.sqrt(1 + 4 * x / y) / math.sqrt(20 * y)
    return part1 + part2 + part3 + part4


if __name__ == '__main__':
    result = cv()
    print_user_cv(result[0], result[3])

    print(calculate_formula(18, 20))
