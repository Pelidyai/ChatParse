from ChatParser import ChatParser
import sys
import argparse
arg_parser = argparse.ArgumentParser()
#arg_parser.add_argument("url")
url = sys.argv[1]
tel_str = sys.argv[2]
is_tel = False
print(tel_str)
if tel_str == "True":
    is_tel = True
#print(is_tel)
#parser = ChatParser("https://t.me/chat_design_russia")
parser = ChatParser(url, is_tel=is_tel)


async def main():
    await parser.dump_all_participants()
    print("done")


with parser.client:
    parser.client.loop.run_until_complete(main())

