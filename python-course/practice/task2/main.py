from tkinter import *
from tkinter.messagebox import showinfo


class MainFrame(Frame):
    def __init__(self, parent):
        super().__init__(parent)

        options = {'padx': 5, 'pady': 5}
        # label
        self.label = Label(self, text='Welcome to the CV Generator !')
        self.label.pack(**options)
        # show the frame on the container
        self.pack(**options)


class App(Tk):
    def __init__(self):
        super().__init__()

        self.title('CV generator')
        self.geometry('600x400')
        self.resizable(False, False)

        # configure the grid
        self.columnconfigure(0, weight=1)
        self.columnconfigure(1, weight=3)

        self.create_widgets()

    def create_widgets(self):
        # username
        username_label = Label(self, text="Username:")
        username_label.grid(column=0, row=0, sticky=W, padx=5, pady=5)

        username_entry = Entry(self)
        username_entry.grid(column=1, row=0, sticky=E, padx=5, pady=5)

        # password
        password_label = Label(self, text="Password:")
        password_label.grid(column=0, row=1, sticky=W, padx=5, pady=5)

        password_entry = Entry(self, show="*")
        password_entry.grid(column=1, row=1, sticky=E, padx=5, pady=5)

        # login button
        login_button = Button(self, text="Login")
        login_button.grid(column=1, row=3, sticky=E, padx=5, pady=5)


if __name__ == "__main__":
    app = App()
    #frame = MainFrame(app)
    app.mainloop()
