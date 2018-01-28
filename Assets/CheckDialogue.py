# This script checks that the dialogue script contains correct audio references.
import pathlib
rsrc = pathlib.Path(__file__).parent / 'Resources'
ref_files = set()
for line in (rsrc / 'Dialogue Script.txt').open():
    line = line.strip()
    if not line or line.startswith('%') or line.startswith('#'):
        continue
    audio = line[:line.index(':')].strip()
    if not audio:
        continue
    if audio in ref_files:
        print('Duplicate audio ref: {}'.format(ref_files))
    ref_files.add(audio)
exist_files = set()
for path in rsrc.glob('S*.wav'):
    exist_files.add(path.stem)
diff = ref_files.symmetric_difference(exist_files)
if not diff:
    print('Ok')
else:
    print('Extra:')
    for name in sorted(exist_files.difference(ref_files)):
        print('  ' + name)
    print('Missing:')
    for name in sorted(ref_files.difference(exist_files)):
        print('  ' + name)
