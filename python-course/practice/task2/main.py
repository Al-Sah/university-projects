from buttonsFrames import *
from inputFrames import *


class App(tk.Tk):

    def __init__(self):
        super().__init__()
        self.userData = {}
        self.title('CV generator')
        self.geometry('600x400')
        self.minsize(500, 200)
        self.maxsize(800, 600)
        self.resizable(True, True)

        self.columnconfigure(0, weight=1)
        self.rowconfigure(0, weight=6)
        self.rowconfigure(1, weight=1)

        self.buttons = {0: StartButtonsFrame(self), 1: NextPrevButtonsFrame(self), 2: FinishButtonsFrame(self)}
        self.currentButtonsFrameId = 0
        self.changeButtonsFrame(self.currentButtonsFrameId)

        self.inputs = [WelcomeFrame(self), BasicInputFrame(self, self.userData)]
        self.currentInputFrameId = 0
        self.changeInputsFrame(self.currentButtonsFrameId)

    def handleFrameBtnClick(self, val):
        if val == "Start":
            self.changeButtonsFrame(1)
            self.changeInputsFrame(1)
        if val == "Next":
            self.changeButtonsFrame(self.currentButtonsFrameId + 1)
            self.changeInputsFrame(self.currentInputFrameId + 1)
        if val == "Previous":
            self.changeButtonsFrame(self.currentButtonsFrameId - 1)
            self.changeInputsFrame(self.currentInputFrameId - 1)

    def changeButtonsFrame(self, frameid):
        self.currentButtonsFrameId = frameid
        self.buttons[frameid].tkraise()

    def changeInputsFrame(self, frameid):
        self.currentInputFrameId = frameid
        self.inputs[frameid].tkraise()


if __name__ == "__main__":
    app = App()
    app.mainloop()
