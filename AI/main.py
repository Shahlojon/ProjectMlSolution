from fastapi import FastAPI
import analyz
from pydantic import BaseModel

class Item(BaseModel):
    Topic: str
    Algorithm: str
    Description: str | None = None
app = FastAPI()


@app.post("/analyze")
async def read_essay_item(item: Item):
    new_theme = analyz.get_theme(item.Description, item.Algorithm)
    percent = analyz.get_ratio(item.Topic, new_theme)
    items = {"Theme": item.Topic, "Description": item.Description, "Algorithm":item.Algorithm, "NewTheme": new_theme, "Percent": percent }
   
    return items