import tkinter as tk


class ButtonsFrame(tk.Frame):
    options = {'padx': 10, 'pady': 10}

    def __init__(self, parent):
        super().__init__(parent)
        self.setup(parent)
        self.grid(column=0, row=1, padx=5, pady=5, sticky=tk.EW)
        # self.pack(fill=tk.X, side=tk.BOTTOM)

    def setup(self, parent):
        pass


class StartButtonsFrame(ButtonsFrame):

    def __init__(self, parent):
        super().__init__(parent)

    def setup(self, parent):
        self.columnconfigure(0, weight=1)
        tk.Button(
            self,
            text='Start',
            command=lambda: parent.handleFrameBtnClick("Start")
        ).grid(column=0, row=0, **self.options)  # sticky=tk.NSEW == fill


class FinishButtonsFrame(ButtonsFrame):

    def __init__(self, parent):
        super().__init__(parent)

    def setup(self, parent):
        self.columnconfigure(0, weight=1)
        self.columnconfigure(1, weight=1)

        tk.Button(
            self,
            text='Previous',
            command=lambda: parent.handleFrameBtnClick("Previous")
        ).grid(column=0, row=0, sticky=tk.E, **self.options)

        tk.Button(
            self,
            text="Show result",
            command=lambda: parent.handleFrameBtnClick("result")
        ).grid(column=1, row=0, sticky=tk.W, **self.options)


class NextPrevButtonsFrame(ButtonsFrame):

    def __init__(self, parent):
        super().__init__(parent)

    def setup(self, parent):
        self.columnconfigure(0, weight=1)
        self.columnconfigure(1, weight=1)

        tk.Button(
            self,
            text='Previous',
            command=lambda: parent.handleFrameBtnClick("Previous")
        ).grid(column=0, row=0, sticky=tk.E, **self.options)

        tk.Button(
            self,
            text='Next',
            command=lambda: parent.handleFrameBtnClick("Next")
        ).grid(column=1, row=0, sticky=tk.W, **self.options)
