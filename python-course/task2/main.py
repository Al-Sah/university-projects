import json
from tkinter import filedialog

from buttonsFrames import *
from inputFrames import *


def fileSave(data):
    file = filedialog.asksaveasfile(mode='w', defaultextension=".json")
    if file is None:
        return
    file.write(json.dumps(data, indent=4))
    file.close()


class ResultDialogWindow(tk.Toplevel):
    def __init__(self, root, data):
        super().__init__(root)
        self.geometry("520x450")
        self.resizable(False, False)
        self.title("result")

        txtFrame = tk.Frame(self)

        txt = tk.Text(txtFrame, width=60, height=22)
        txt.insert("end-1c", json.dumps(data, indent=4))
        txt.config(state=tk.DISABLED)
        txt.pack(side=tk.LEFT)

        scroll = tk.Scrollbar(txtFrame, command=txt.yview)
        scroll.pack(side=tk.LEFT, fill=tk.Y)
        txt.config(yscrollcommand=scroll.set)

        txtFrame.pack(pady=10, padx=10, side=tk.TOP, fill=tk.BOTH,  expand=True)

        tk.Button(self, text="Save to file", command=lambda: fileSave(data))\
            .pack(pady=10, padx=10, fill=tk.BOTH, side=tk.TOP)


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

        self.buttons = [StartButtonsFrame(self), NextPrevButtonsFrame(self), FinishButtonsFrame(self)]
        self.currentButtonsFrameId = 0
        self.changeButtonsFrame(self.currentButtonsFrameId)

        self.inputs = [WelcomeFrame(self), BasicInputFrame(self, self.userData),
                       ExtraInfoInputFrame(self, self.userData)]
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

        if val == "result":
            for frame in self.inputs:
                frame.save()
            ResultDialogWindow(self, self.userData)

    def changeButtonsFrame(self, frameid):
        self.currentButtonsFrameId = frameid
        self.buttons[frameid].tkraise()

    def changeInputsFrame(self, frameid):
        self.currentInputFrameId = frameid
        self.inputs[frameid].tkraise()


if __name__ == "__main__":
    app = App()
    app.mainloop()
