import tkinter as tk


class InputFrame(tk.Frame):

    def __init__(self, parent):
        super().__init__(parent)
        self.setup(parent)
        self.grid(column=0, row=0, padx=5, pady=5, sticky=tk.NSEW)

    def setup(self, parent):
        pass


class WelcomeFrame(InputFrame):

    def __init__(self, parent):
        super().__init__(parent)

    def setup(self, parent):
        tk.Label(
            self,
            text='Hello user !\n Click "Start" button to create your CV',
            font=("Helvetica", 14)
        ).pack(expand=True)
