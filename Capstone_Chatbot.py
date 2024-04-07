import openai
import gradio
openai.api_key = "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"

messages = [{"role": "system", "content": "You are a Medical experts that specializes in helping patient to get cure from Tuberculosis"}]

def TBDetectionChatbot(user_input):
    messages.append({"role": "user", "content": "Patient"})
    response = openai.ChatCompletion.create(
        model = "gpt-3.5-turbo",
        messages = messages
    )
    ChatGPT_reply = response["choices"][0]["message"]["content"]
    messages.append({"role": "assistant", "content": ChatGPT_reply})
    return ChatGPT_reply

demo = gradio.Interface(fn=TBDetectionChatbot, inputs = "text", outputs = "text", title = "Tuberculosis Chatbot")

demo.launch(share=True)
