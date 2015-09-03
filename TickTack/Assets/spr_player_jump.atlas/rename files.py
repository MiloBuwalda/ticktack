import os
import shutil

os.path.abspath('/Users/egges/Desktop/spr_player_jump.atlas')
for x in range(0, 14):
    # first construct the string
    strNr = "%d" % x
    oldfile = 'spr_player_jump_' + str(x) + '@1x.png'
    print oldfile
    newfile = 'spr_player_jump_' + str(x) + '@2x.png'
    shutil.copy2(oldfile, newfile)
#os.rename(oldfile, newfile)
