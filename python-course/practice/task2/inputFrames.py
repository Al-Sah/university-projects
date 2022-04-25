import tkinter as tk


class InputFrame(tk.Frame):

    def __init__(self, parent, userdata):
        super().__init__(parent)
        self.userdata = userdata
        self.setup(parent)
        self.grid(column=0, row=0, padx=5, pady=5, sticky=tk.NSEW)

    def setup(self, parent):
        pass

    def save(self):
        pass


class WelcomeFrame(InputFrame):

    def __init__(self, parent):
        super().__init__(parent, None)

    def setup(self, parent):
        tk.Label(
            self,
            text='Hello user !\n Click "Start" button to create your CV',
            font=("Helvetica", 14)
        ).pack(expand=True)


class BasicInputFrame(InputFrame):

    def __init__(self, parent, userdata):
        self.values = list(range(500, 10001, 500))
        self.salaryInput = None
        self.locationInput = None
        self.educationInput = None
        self.birthInput = None
        self.nameInput = None
        self.surnameInput = None
        self.patronymicInput = None
        self.salarySlider = None
        self.selectedRadio = None
        super().__init__(parent, userdata)

    def setup(self, parent):
        self.rowconfigure(0, weight=1)
        self.rowconfigure(1, weight=1)
        self.columnconfigure(0, weight=1)
        self.columnconfigure(1, weight=1)
        self.setupFullnameInputFrame()
        self.setupUserInfoInputFrame()
        self.setupSalaryInputFrame()

    def setupFullnameInputFrame(self):
        frame = tk.Frame(self)
        frame.columnconfigure(0, weight=1)
        frame.columnconfigure(1, weight=2)

        tk.Label(frame, text='Lets start with your full name', font=("Helvetica", 14)) \
            .grid(column=0, row=0, columnspan=2, sticky=tk.EW + tk.S, padx=5, pady=20)

        self.nameInput = tk.Entry(frame)
        self.surnameInput = tk.Entry(frame)
        self.patronymicInput = tk.Entry(frame)

        # name
        tk.Label(frame, text="Name:").grid(column=0, row=1, sticky=tk.E)
        self.nameInput.grid(column=1, row=1, sticky=tk.EW, padx=10, pady=4)
        # surname
        tk.Label(frame, text="Surname:").grid(column=0, row=2, sticky=tk.E)
        self.surnameInput.grid(column=1, row=2, sticky=tk.EW, padx=10, pady=4)
        # patronymic
        tk.Label(frame, text="Patronymic:").grid(column=0, row=3, sticky=tk.E)
        self.patronymicInput.grid(column=1, row=3, sticky=tk.EW, padx=10, pady=4)

        frame.grid(column=0, row=0, sticky=tk.NSEW)

    def setupUserInfoInputFrame(self):
        usrinfo = tk.Frame(self)
        usrinfo.columnconfigure(0, weight=1)
        usrinfo.columnconfigure(1, weight=2)

        tk.Label(usrinfo, text='Fill other details ...', font=("Helvetica", 14)) \
            .grid(column=0, row=0, columnspan=2, sticky=tk.EW + tk.S, padx=5, pady=20)

        self.birthInput = tk.Entry(usrinfo)
        self.educationInput = tk.Entry(usrinfo)
        self.locationInput = tk.Entry(usrinfo)

        # Birth
        tk.Label(usrinfo, text="Year of birth: ").grid(column=0, row=1, sticky=tk.E)
        self.birthInput.grid(column=1, row=1, sticky=tk.EW, padx=10, pady=4)
        # Education
        tk.Label(usrinfo, text="Education: ").grid(column=0, row=2, sticky=tk.E)
        self.educationInput.grid(column=1, row=2, sticky=tk.EW, padx=10, pady=4)
        # Location
        tk.Label(usrinfo, text="Location: ").grid(column=0, row=3, sticky=tk.E)
        self.locationInput.grid(column=1, row=3, sticky=tk.EW, padx=10, pady=4)

        usrinfo.grid(column=1, row=0, sticky=tk.NSEW)

    def setupSalaryInputFrame(self):
        frame = tk.Frame(self)
        frame.columnconfigure(0, weight=1)
        frame.columnconfigure(1, weight=1)
        frame.columnconfigure(2, weight=1)

        tk.Label(frame, text=' Expected salary (in USD)', font=("Helvetica", 14)) \
            .grid(column=0, row=0, columnspan=3, sticky=tk.EW + tk.S, padx=5, pady=5)

        self.selectedRadio = tk.IntVar()
        tk.Radiobutton(frame, value=0, variable=self.selectedRadio, command=self.onRadio)\
            .grid(column=0, row=1, padx=5, pady=5, sticky=tk.E)
        tk.Radiobutton(frame, value=1, variable=self.selectedRadio, command=self.onRadio)\
            .grid(column=0, row=2, padx=5, pady=5, sticky=tk.E)

        self.salaryInput = tk.Entry(frame)
        self.salaryInput.grid(column=1, row=1, columnspan=2, sticky=tk.EW, padx=(0, 100), pady=4)

        self.salarySlider = tk.Scale(
            frame,
            from_=500, to=10000,
            orient='horizontal',
            state=tk.DISABLED,
            command=self.valuecheck
        )
        self.salarySlider.grid(column=1, row=2, columnspan=2, sticky=tk.EW, padx=(5, 100), pady=10)

        frame.grid(column=0, row=1, columnspan=2, sticky=tk.NSEW)

    def onRadio(self):
        if self.selectedRadio.get() == 0:
            self.salarySlider.config(state=tk.DISABLED)
            self.salaryInput.config(state=tk.NORMAL)
        if self.selectedRadio.get() == 1:
            self.salarySlider.config(state=tk.ACTIVE)
            self.salaryInput.config(state=tk.DISABLED)

    def valuecheck(self, value):
        self.salarySlider.set(min(self.values, key=lambda x: abs(x - float(value))))

    def save(self):
        self.userdata["name"] = self.nameInput.get()
        self.userdata["surname"] = self.surnameInput.get()
        self.userdata["patronymic"] = self.patronymicInput.get()
        self.userdata["birth"] = self.birthInput.get()
        self.userdata["education"] = self.educationInput.get()
        self.userdata["location"] = self.locationInput.get()
        if self.selectedRadio.get() == 0:
            self.userdata["salary"] = self.salaryInput.get()
        else:
            self.userdata["salary"] = self.salarySlider.get()
