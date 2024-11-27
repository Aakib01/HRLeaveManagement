import openai
openai.api_key = "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"

model = "text-davinci-003"
question = "Who is the chief minister of Tamilnadu 2022"

response = openai.Completion.create(
    engine=model,
    prompt=(f"Question: {question}\n"
            "Answer:"
            ),
    max_tokens=100,
    n=1,
    stop=None,
    temperature=0.5
)

answer = response.choices[0].text.split('\n')[0]
print(answer)